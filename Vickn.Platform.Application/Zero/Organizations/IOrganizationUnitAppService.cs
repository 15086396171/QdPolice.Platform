using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Vickn.Platform.Organizations.Dto;

namespace Vickn.Platform.Organizations
{
    public interface IOrganizationUnitAppService : IApplicationService
    {
        /// <summary>
        /// 获取所有组织 
        /// </summary>
        /// <returns></returns>
        Task<List<OrganizationUnitDto>> GetOrganizationUnitDto();

        /// <summary>
        /// 获取组织和用户
        /// </summary>
        /// <returns></returns>
        Task<List<OuWithUserDto>> GetOuWithUsersAsync(); 

            /// <summary>
        /// 根据查询条件获取组织分页列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<OrganizationUnitDto>> GetPagedOrganizationUnitAsync(GetOrganizationUnitInput input);

        /// <summary>
        /// 根据查询条件获取该组织下用户分页列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<OrganizationUnitUserListDto>> GetOrganizationUnitUsers(GetOrganizationUnitUsersInput input);

        /// <summary>
        /// 获取所有用户在该组织下的选择情况用于修改用户组织
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<OrganizationUnitUserListDto>> GetOrganizationUnitWithAllUserForAdd(GetOrganizationUnitUsersInput input);

        /// <summary>
        /// 批量添加用户到Ou中
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task AddUserToOuAsync(AddUserToOuInput input);

        Task<GetOrganizationUnitForEditOutput> GetOrganizationUnitForEditAsync(NullableIdDto<long> input);

        Task CreateOrUpdateOrganizationUnit(GetOrganizationUnitForEditOutput output);

        /// <summary>
        /// 创建组织
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<OrganizationUnitDto> CreateOrganizationUnit(CreateOrganizationUnitInput input);

        /// <summary>
        /// 编辑组织
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<OrganizationUnitDto> UpdateOrganizationUnit(UpdateOrganizationUnitInput input);

        /// <summary>
        /// 移动组织
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<OrganizationUnitDto> MoveOrganizationUnit(MoveOrganizationUnitInput input);

        /// <summary>
        /// 删除组织
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>

        Task DeleteOrganizationUnit(EntityDto<long> input);

        Task BatchDeleteOrganizationUnitAsync(List<long> input);

        /// <summary>
        /// 添加用户到组织中
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>

        Task AddUserToOrganizationUnit(UserToOrganizationUnitInput input);

        /// <summary>
        /// 从组织中删除用户
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task RemoveUserFromOrganizationUnit(UserToOrganizationUnitInput input);

        /// <summary>
        /// 获取用户是否在组织中
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<bool> IsInOrganizationUnit(UserToOrganizationUnitInput input);
    }
}
