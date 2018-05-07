using System;
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
using Abp.Domain.Uow;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Abp.UI;
using Microsoft.AspNet.Identity;
using Vickn.PlatfForm.Utils.Extensions;
using Vickn.Platform.Authorization;
using Vickn.Platform.Users.Dto;
using Vickn.Platform.Authorization.Roles;
using Vickn.Platform.Dtos;
using Vickn.Platform.Users.Authorization;
using Vickn.Platform.Users.Dtos;
using Vickn.Platform.Zero.Users.Dtos;

namespace Vickn.Platform.Users
{
    public class UserAppService : PlatformAppServiceBase, IUserAppService
    {
        private readonly IRepository<User, long> _userRepository;
        private readonly IPermissionManager _permissionManager;
        private readonly RoleManager _roleManager;
        private readonly IRepository<UserOrganizationUnit, long> _userOrganizationRepository;
        private readonly IRepository<UserRole, long> _userRoleRepository;

        public UserAppService(IRepository<User, long> userRepository, IPermissionManager permissionManager, RoleManager roleManager, IRepository<UserOrganizationUnit, long> userOrganizationRepository, IRepository<UserRole, long> userRoleRepository)
        {
            _userRepository = userRepository;
            _permissionManager = permissionManager;
            _roleManager = roleManager;
            _userOrganizationRepository = userOrganizationRepository;
            _userRoleRepository = userRoleRepository;
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
            var deviceId = AbpSession.GetDeviceId();

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

        #region 用户管理管理

        /// <summary>
        /// 根据查询条件获取用户管理分页列表
        /// </summary>
        public async Task<PagedResultDto<UserListDto>> GetPagedUsersAsync(GetUserInput input)
        {
            var maxWeight = await _roleManager.GetMaxWeightByUserIdAsync(AbpSession.UserId.Value);
            var query = (from user in _userRepository.GetAll()
                         join userRole in _userRoleRepository.GetAll() on user.Id equals userRole.UserId
                             into t
                         from a in t.DefaultIfEmpty()
                         where (from role in _roleManager.Roles
                                where t.Select(p => p.RoleId).Contains(role.Id)
                                select role).Max(p => p.Weight) <= maxWeight || a == null
                         select user).Distinct();

            //TODO:根据传入的参数添加过滤条件

            if (input.OuId.HasValue)
            {
                query = from user in query
                        join userOrganizationUnit in _userOrganizationRepository.GetAll() on user.Id equals
                        userOrganizationUnit.UserId
                        where userOrganizationUnit.OrganizationUnitId == input.OuId.Value
                        select user;
            }

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
        /// 通过Id获取用户管理信息进行编辑或修改 
        /// </summary>
        public async Task<GetUserForEdit> GetUserForEditAsync(NullableIdDto<long> input)
        {
            var myroles = await _roleManager.FindByUserIdAsync(AbpSession.UserId.Value);
            var myMax = myroles.Max(r => r.Weight);
            var userRoleDtos = (await _roleManager.Roles
                .Where(p => p.Weight <= myMax)
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
                // 创建时选中默认角色
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
        /// 通过指定id获取用户管理ListDto信息
        /// </summary>
        public async Task<UserListDto> GetUserByIdAsync(EntityDto<long> input)
        {
            var entity = await _userRepository.GetAsync(input.Id);

            return entity.MapTo<UserListDto>();
        }

        /// <summary>
        /// 通过用户名获取用户信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<UserListDto> GetUserByNameAsync(EntityDto<string> input)
        {
            var user = await _userRepository.FirstOrDefaultAsync(p => p.UserName == input.Id);
            return user.MapTo<UserListDto>();
        }


        /// <summary>
        /// 新增或更改用户管理
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
        /// 检查用户输入错误
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<CustomerModelStateValidationDto> CheckErrorAsync(GetUserForEdit input)
        {
            if (await _userRepository.FirstOrDefaultAsync(p => p.UserName == input.UserEditDto.UserName && p.Id != input.UserEditDto.Id) != null)
            {
                return new CustomerModelStateValidationDto()
                {
                    HasModelError = true,
                    ErrorMessage = $"登录名{input.UserEditDto.UserName}已存在",
                    Key = "UserEditDto.UserName"
                };
            }

            if (await _userRepository.FirstOrDefaultAsync(p => p.EmailAddress == input.UserEditDto.EmailAddress && p.Id != input.UserEditDto.Id) != null)
                return new CustomerModelStateValidationDto()
                {
                    HasModelError = true,
                    ErrorMessage = $"电子邮件{input.UserEditDto.EmailAddress}已存在",
                    Key = "UserEditDto.EmailAddress"
                };
            return new CustomerModelStateValidationDto() { HasModelError = false };
        }

        /// <summary>
        /// 新增用户管理
        /// </summary>
        public virtual async Task<UserEditDto> CreateUserAsync(GetUserForEdit input)
        {
            //TODO:新增前的逻辑判断，是否允许新增
            var user = input.UserEditDto.MapTo<User>();

            user.TenantId = AbpSession.TenantId;
            user.Password = new PasswordHasher().HashPassword(User.DefaultPassword);
            user.IsEmailConfirmed = true;
            user.EmailAddress = user.EmailAddress.IsNullOrEmpty() ? user.PhoneNumber + "@default.com" : user.EmailAddress;
            user.Surname = user.Name;
            // 默认启用
            user.IsActive = true;

            user.Roles = new List<UserRole>();
            foreach (var userRoleDto in input.UserRoleDtos.Where(p => p.IsAssigned))
            {
                user.Roles.Add(new UserRole { RoleId = userRoleDto.RoleId });
            }
            user.Id = await _userRepository.InsertAndGetIdAsync(user);

            if (input.OuId.HasValue)
            {
                await UserManager.AddToOrganizationUnitAsync(user.Id, input.OuId.Value);
            }

            return user.MapTo<UserEditDto>();
        }

        /// <summary>
        /// 添加带密码的用户、导入使用
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task CreateManyWithPassword(UserEditDtoWithPassword input)
        {
            //TODO:新增前的逻辑判断，是否允许新增
            if (_userRepository.FirstOrDefault(p => p.UserName == input.UserName) != null)
                return;

            var user = input.MapTo<User>();
            user.TenantId = AbpSession.TenantId;
            user.Password = new PasswordHasher().HashPassword(input.Password);
            user.IsEmailConfirmed = true;
            if (!user.PhoneNumber.IsNullOrEmpty())
            {
                user.EmailAddress = user.EmailAddress.IsNullOrEmpty()
                    ? user.PhoneNumber + "@default.com"
                    : user.EmailAddress;
            }
            else
            {
                user.EmailAddress = Guid.NewGuid().ToString("N").Truncate(6) + "@default.com";
            }
            user.Surname = user.Name;
            // 默认启用
            user.IsActive = true;

            user.Roles = new List<UserRole>();

            var roles = await _roleManager.Roles.Where(p => p.IsDefault).ToListAsync();

            foreach (var role in roles)
            {
                user.Roles.Add(new UserRole
                {
                    RoleId = role.Id
                });
            }

            user.Id = await _userRepository.InsertAndGetIdAsync(user);

        }

        /// <summary>
        /// 编辑用户管理
        /// </summary>
        public virtual async Task UpdateUserAsync(GetUserForEdit input)
        {
            //TODO:更新前的逻辑判断，是否允许更新

            var entity = await _userRepository.GetAsync(input.UserEditDto.Id.Value);
            input.UserEditDto.MapTo(entity);

            await _userRepository.UpdateAsync(entity);

            var roleNames = input.UserRoleDtos.Where(p => p.IsAssigned).Select(p => p.RoleName).ToArray();
            await UserManager.SetRoles(entity, roleNames);

        }

        /// <summary>
        /// 删除用户管理
        /// </summary>
        public async Task DeleteUserAsync(EntityDto<long> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            if (_userRepository.FirstOrDefault(input.Id).UserName != PlatformConsts.UserConst.DefaultAdminUserName)
                await _userRepository.DeleteAsync(input.Id);
        }

        /// <summary>
        /// 批量删除用户管理
        /// </summary>
        public async Task BatchDeleteUserAsync(List<long> input)
        {
            //TODO:批量删除前的逻辑判断，是否允许删除
            var admin = await
                _userRepository.FirstOrDefaultAsync(p => p.UserName == PlatformConsts.UserConst.DefaultAdminUserName);
            input.Remove(admin.Id);
            await _userRepository.DeleteAsync(s => input.Contains(s.Id));
        }

        /// <summary>
        /// 停用或启用用户
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task DisableUserAsync(EntityDto<long> input)
        {
            var user = await _userRepository.GetAsync(input.Id);
            user.IsActive = !user.IsActive;
        }

        /// <summary>
        /// 获取我的信息
        /// </summary>
        /// <returns></returns>
        public async Task<GetUserForEdit> GetMyInfoAsync()
        {
            return await GetUserForEditAsync(new NullableIdDto<long>(AbpSession.UserId));
        }

        /// <summary>
        /// 重置密码
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(UserAppPermissions.User_ResetPasswordUser)]
        public async Task ResetPasswordAsync(EntityDto<long> input)
        {
            var user = await UserManager.GetUserByIdAsync(input.Id);
            user.Password = new PasswordHasher().HashPassword(User.DefaultPassword);

            user.SetNewPasswordResetCode();
            user.ShouldChangePasswordOnNextLogin = true;

            await UserManager.UpdateAsync(user);
        }

        /// <summary>
        /// 修改用户头像
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task ChangeProfilePic(ChangeProfilePicDto dto)
        {
            var user = await _userRepository.FirstOrDefaultAsync(dto.Id);
            user.ProfilePictureId = dto.ProfilePictureId;
        }

        /// <summary>
        /// 设置系统中所有用户的默认角色
        /// </summary>
        /// <returns></returns>
        public async Task SetDefaultRolesAsync()
        {
            var users = await _userRepository.GetAllListAsync();
            var roles = await _roleManager.Roles.Where(p => p.IsDefault).ToListAsync();
            foreach (var user in users)
            {
                foreach (var role in roles)
                {
                    if (user.Roles.FirstOrDefault(p => p.RoleId == role.Id) == null)
                    {
                        user.Roles.Add(new UserRole()
                        {
                            RoleId = role.Id
                        });
                    }
                }
            }
        }

        public async Task<List<UserListDto>> GetUserslist()
        {


            var users = await _userRepository.GetAllListAsync();

            return new List<UserListDto>(
                users.MapTo<List<UserListDto>>());
        }

      


        #endregion
    }
}