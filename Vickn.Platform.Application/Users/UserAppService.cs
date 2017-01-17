using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Vickn.Platform.Authorization;
using Vickn.Platform.Users.Dto;
using Microsoft.AspNet.Identity;
using Vickn.Platform.Users.Authorization;
using Vickn.Platform.Users.Dtos;

namespace Vickn.Platform.Users
{
    /* THIS IS JUST A SAMPLE. */
    [AbpAuthorize(AppPermissions.Pages_Users)]
    public class UserAppService : PlatformAppServiceBase, IUserAppService
    {
        private readonly IRepository<User, long> _userRepository;
        private readonly IPermissionManager _permissionManager;

        public UserAppService(IRepository<User, long> userRepository, IPermissionManager permissionManager)
        {
            _userRepository = userRepository;
            _permissionManager = permissionManager;
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

            var query = _userRepository.GetAll();
            //TODO:根据传入的参数添加过滤条件

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
        public async Task<GetUserForEditOutput> GetUserForEditAsync(NullableIdDto<long> input)
        {
            var output = new GetUserForEditOutput();

            UserEditDto userEditDto;

            if (input.Id.HasValue)
            {
                var entity = await _userRepository.GetAsync(input.Id.Value);
                userEditDto = entity.MapTo<UserEditDto>();
            }
            else
            {
                userEditDto = new UserEditDto();
            }

            output.User = userEditDto;
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
        /// 新增或更改用户管理
        /// </summary>
        public async Task CreateOrUpdateUserAsync(CreateOrUpdateUserInput input)
        {
            if (input.UserEditDto.Id.HasValue)
            {
                await UpdateUserAsync(input.UserEditDto);
            }
            else
            {
                await CreateUserAsync(input.UserEditDto);
            }
        }

        /// <summary>
        /// 新增用户管理
        /// </summary>
        [AbpAuthorize(UserAppPermissions.User_CreateUser)]
        public virtual async Task<UserEditDto> CreateUserAsync(UserEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增

            var entity = input.MapTo<User>();

            entity = await _userRepository.InsertAsync(entity);
            return entity.MapTo<UserEditDto>();
        }

        /// <summary>
        /// 编辑用户管理
        /// </summary>
        [AbpAuthorize(UserAppPermissions.User_EditUser)]
        public virtual async Task UpdateUserAsync(UserEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新

            var entity = await _userRepository.GetAsync(input.Id.Value);
            input.MapTo(entity);

            await _userRepository.UpdateAsync(entity);
        }

        /// <summary>
        /// 删除用户管理
        /// </summary>
        [AbpAuthorize(UserAppPermissions.User_DeleteUser)]
        public async Task DeleteUserAsync(EntityDto<long> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _userRepository.DeleteAsync(input.Id);
        }

        /// <summary>
        /// 批量删除用户管理
        /// </summary>
        [AbpAuthorize(UserAppPermissions.User_DeleteUser)]
        public async Task BatchDeleteUserAsync(List<long> input)
        {
            //TODO:批量删除前的逻辑判断，是否允许删除
            await _userRepository.DeleteAsync(s => input.Contains(s.Id));
        }

        #endregion
    }
}