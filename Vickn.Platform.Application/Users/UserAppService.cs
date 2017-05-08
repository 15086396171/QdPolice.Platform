using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Authorization.Users;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Abp.UI;
using Microsoft.AspNet.Identity;
using Vickn.Platform.Authorization;
using Vickn.Platform.Users.Dto;
using Vickn.Platform.Authorization.Roles;
using Vickn.Platform.Dtos;
using Vickn.Platform.Users.Authorization;
using Vickn.Platform.Users.Dtos;

namespace Vickn.Platform.Users
{
    public class UserAppService : PlatformAppServiceBase, IUserAppService
    {
        private readonly IRepository<User, long> _userRepository;
        private readonly IPermissionManager _permissionManager;
        private readonly RoleManager _roleManager;

        public UserAppService(IRepository<User, long> userRepository, IPermissionManager permissionManager,RoleManager roleManager)
        {
            _userRepository = userRepository;
            _permissionManager = permissionManager;
            _roleManager = roleManager;
        }

        public async Task ProhibitPermission(ProhibitPermissionInput input)
        {
            var user = await UserManager.GetUserByIdAsync(input.UserId);
            var permission = _permissionManager.GetPermission(input.PermissionName);
            await UserManager.ProhibitPermissionAsync(user, permission);
        }

        //Example for primitive method parameters.
        public async Task RemoveFromRole(long userId, string roleName)
        {
            CheckErrors(await UserManager.RemoveFromRoleAsync(userId, roleName));
        }

        public async Task<ListResultDto<UserListDto>> GetUsers()
        {
             var a= AbpSession.UserId;
            var users = await _userRepository.GetAllListAsync();

            return new ListResultDto<UserListDto>(
                users.MapTo<List<UserListDto>>()
                );
        }

        public async Task CreateUser(CreateUserInput input)
        {
            var user = input.MapTo<User>();

            user.TenantId = AbpSession.TenantId;
            user.Password = new PasswordHasher().HashPassword(input.Password);
            user.IsEmailConfirmed = true;

            CheckErrors(await UserManager.CreateAsync(user));
        }

        #region �û��������

        /// <summary>
        /// ���ݲ�ѯ������ȡ�û������ҳ�б�
        /// </summary>
        public async Task<PagedResultDto<UserListDto>> GetPagedUsersAsync(GetUserInput input)
        {

            var query = _userRepository.GetAll();
            //TODO:���ݴ���Ĳ�����ӹ�������

            query = query.WhereIf(!input.Name.IsNullOrEmpty(), p => p.Name.Contains(input.Name));

            var userCount = await query.CountAsync();

            var users = await query
            .OrderBy(input.Sorting)
            .PageBy(input)
            .ToListAsync();

            var userListDtos = users.MapTo<List<UserListDto>>();
            return new PagedResultDto<UserListDto>(
            userCount,
            userListDtos
            );
        }

        /// <summary>
        /// ͨ��Id��ȡ�û�������Ϣ���б༭���޸� 
        /// </summary>
        public async Task<GetUserForEdit> GetUserForEditAsync(NullableIdDto<long> input)
        {
            var userRoleDtos = (await _roleManager.Roles
              .OrderBy(r => r.DisplayName)
              .Select(r => new UserRoleDto
              {
                  RoleId = r.Id,
                  RoleName = r.Name,
                  RoleDisplayName = r.DisplayName
              })
              .ToArrayAsync());
            var output = new GetUserForEdit();

            UserEditDto userEditDto;

            if (input.Id.HasValue)
            {
                var entity = await _userRepository.GetAsync(input.Id.Value);
                userEditDto = entity.MapTo<UserEditDto>();
                foreach (var userRoleDto in userRoleDtos)
                {
                    userRoleDto.IsAssigned = await UserManager.IsInRoleAsync(input.Id.Value, userRoleDto.RoleName);
                }
            }
            else
            {
                userEditDto = new UserEditDto()
                {
                    ShouldChangePasswordOnNextLogin = true
                };
                // ����ʱѡ��Ĭ�Ͻ�ɫ
                foreach (var defaultRole in await _roleManager.Roles.Where(r => r.IsDefault).ToListAsync())
                {
                    var defaultUserRole = userRoleDtos.FirstOrDefault(ur => ur.RoleName == defaultRole.Name);
                    if (defaultUserRole != null)
                    {
                        defaultUserRole.IsAssigned = true;
                    }
                }
            }
            output.UserRoleDtos = userRoleDtos;
            output.UserEditDto = userEditDto;
            return output;
        }


        /// <summary>
        /// ͨ��ָ��id��ȡ�û�����ListDto��Ϣ
        /// </summary>
        public async Task<UserListDto> GetUserByIdAsync(EntityDto<long> input)
        {
            var entity = await _userRepository.GetAsync(input.Id);

            return entity.MapTo<UserListDto>();
        }


        /// <summary>
        /// ����������û�����
        /// </summary>
        public async Task CreateOrUpdateUserAsync(GetUserForEdit input)
        {
            if (input.UserEditDto.Id.HasValue)
            {
                await UpdateUserAsync(input);
            }
            else
            {
                await CreateUserAsync(input);
            }
        }

        /// <summary>
        /// ����û��������
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<CustomerModelStateValidationDto> CheckErrorAsync(GetUserForEdit input)
        {
            //input.Id = input.Id ?? 0;
            //if (await _userRepository.FirstOrDefaultAsync(p => p.EmailAddress == input.UserEditDto.EmailAddress && p.Id != input.UserEditDto.Id) != null)
            //    return new CustomerModelStateValidationDto()
            //    {
            //        HasModelError = true,
            //        ErrorMessage = $"�����ʼ�{input.UserEditDto.EmailAddress}�Ѵ���",
            //        Key = "User.EmailAddress"
            //    };

            if (await _userRepository.FirstOrDefaultAsync(p => p.UserName == input.UserEditDto.UserName && p.Id != input.UserEditDto.Id) != null)
            {
                return new CustomerModelStateValidationDto()
                {
                    HasModelError = true,
                    ErrorMessage = $"��¼��{input.UserEditDto.UserName}�Ѵ���",
                    Key = "User.UserName"
                };
            }
            return new CustomerModelStateValidationDto() {HasModelError = false};
        }

        /// <summary>
        /// �����û�����
        /// </summary>
        public virtual async Task<UserEditDto> CreateUserAsync(GetUserForEdit input)
        {
            //TODO:����ǰ���߼��жϣ��Ƿ���������

            var user = input.UserEditDto.MapTo<User>();

            user.TenantId = AbpSession.TenantId;
            user.Password = new PasswordHasher().HashPassword(User.DefaultPassword);
            user.IsEmailConfirmed = true;
            // Ĭ������
            user.IsActive = true;

            user.Roles = new List<UserRole>();
            foreach (var userRoleDto in input.UserRoleDtos.Where(p=>p.IsAssigned))
            {
                user.Roles.Add(new UserRole { RoleId = userRoleDto.RoleId });
            }

            CheckErrors(await UserManager.CreateAsync(user));

            return user.MapTo<UserEditDto>();
        }

        /// <summary>
        /// �༭�û�����
        /// </summary>
        public virtual async Task UpdateUserAsync(GetUserForEdit input)
        {
            //TODO:����ǰ���߼��жϣ��Ƿ��������

            var entity = await _userRepository.GetAsync(input.UserEditDto.Id.Value);
            input.UserEditDto.MapTo(entity);

            await _userRepository.UpdateAsync(entity);

            var roleNames = input.UserRoleDtos.Where(p=>p.IsAssigned).Select(p => p.RoleName).ToArray();
            await UserManager.SetRoles(entity, roleNames);

        }

        /// <summary>
        /// ɾ���û�����
        /// </summary>
        public async Task DeleteUserAsync(EntityDto<long> input)
        {
            //TODO:ɾ��ǰ���߼��жϣ��Ƿ�����ɾ��
            if( _userRepository.FirstOrDefault(input.Id).UserName != PlatformConsts.UserConst.DefaultAdminUserName)
            await _userRepository.DeleteAsync(input.Id);
        }

        /// <summary>
        /// ����ɾ���û�����
        /// </summary>
        public async Task BatchDeleteUserAsync(List<long> input)
        {
            //TODO:����ɾ��ǰ���߼��жϣ��Ƿ�����ɾ��
            var admin = await
                _userRepository.FirstOrDefaultAsync(p => p.UserName == PlatformConsts.UserConst.DefaultAdminUserName);
            input.Remove(admin.Id);
            await _userRepository.DeleteAsync(s => input.Contains(s.Id));
        }

        /// <summary>
        /// ͣ�û������û�
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task DisableUserAsync(EntityDto<long> input)
        {
            var user = await _userRepository.GetAsync(input.Id);
            user.IsActive = !user.IsActive;
        }

        #endregion
    }
}