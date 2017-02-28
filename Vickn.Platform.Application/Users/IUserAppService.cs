using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Vickn.Platform.Dtos;
using Vickn.Platform.Users.Dto;
using Vickn.Platform.Users.Dtos;

namespace Vickn.Platform.Users
{
    public interface IUserAppService : IApplicationService
    {
        Task ProhibitPermission(ProhibitPermissionInput input);

        Task RemoveFromRole(long userId, string roleName);

        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <returns></returns>
        Task<ListResultDto<UserListDto>> GetUsers();

        Task CreateUser(CreateUserInput input);

        #region 用户管理管理

        /// <summary>
        /// 根据查询条件获取用户管理分页列表
        /// </summary>
        Task<PagedResultDto<UserListDto>> GetPagedUsersAsync(GetUserInput input);

        /// <summary>
        /// 通过Id获取用户管理信息进行编辑或修改 
        /// </summary>
        Task<GetUserForEdit> GetUserForEditAsync(NullableIdDto<long> input);

        /// <summary>
        /// 通过指定id获取用户管理ListDto信息
        /// </summary>
        Task<UserListDto> GetUserByIdAsync(EntityDto<long> input);

        /// <summary>
        /// 新增或更改用户管理
        /// </summary>
        Task CreateOrUpdateUserAsync(GetUserForEdit input);

        /// <summary>
        /// 检查用户输入错误
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<CustomerModelStateValidationDto> CheckErrorAsync(GetUserForEdit input);

            /// <summary>
        /// 新增用户管理
        /// </summary>
        Task<UserEditDto> CreateUserAsync(GetUserForEdit input);

        /// <summary>
        /// 更新用户管理
        /// </summary>
        Task UpdateUserAsync(GetUserForEdit input);

        /// <summary>
        /// 删除用户管理
        /// </summary>
        Task DeleteUserAsync(EntityDto<long> input);

        /// <summary>
        /// 批量删除用户管理
        /// </summary>
        Task BatchDeleteUserAsync(List<long> input);

        /// <summary>
        /// 停用或启用用户
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task DisableUser(EntityDto<long> input);

        #endregion
    }
}