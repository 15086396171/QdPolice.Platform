/*
* 命名空间 :     Vickn.Platform.Authorization.Roles
* 类 名  称 :      IRoleAppService 
* 版      本 :      v1.0.0.0
* 文 件  名 :     IRoleAppService.cs
* 描      述 :     角色服务接口
* 创建时间 :     2017/2/20 15:47:01
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Vickn.Platform.Dtos;
using Vickn.Platform.Roles.Dtos;

namespace Vickn.Platform.Roles
{
     /// <summary>
    /// 角色服务接口
    /// </summary>
    public interface IRoleAppService : IApplicationService
    {
        #region 角色管理

        /// <summary>
        /// 更新角色权限
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task UpdateRolePermissionsAsync(UpdateRolePermissionsInput input);

        /// <summary>
        /// 根据角色Id获取角色权限编辑Dto
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
         Task<GetRolePermissionEditDto> GetRolePermissionForEditAsync(EntityDto input);

        /// <summary>
        /// 根据查询条件获取角色分页列表
        /// </summary>
        Task<PagedResultDto<RoleDto>> GetPagedAsync(GetRoleInput input);

        /// <summary>
        /// 通过Id获取角色信息进行编辑或修改
        /// Id为空时返回新对象 
        /// </summary>
        Task<GetRoleForEditOutput> GetForEditAsync(NullableIdDto<int> input);

        /// <summary>
        /// 通过指定id获取角色Dto信息
        /// </summary>
        Task<RoleDto> GetByIdAsync(EntityDto<int> input);

        /// <summary>
        /// 新增或更改角色
        /// </summary>
        Task CreateOrUpdateAsync(CreateOrUpdateRoleInput input);

        /// <summary>
        /// 新增角色
        /// </summary>
        Task<RoleEditDto> CreateAsync(CreateOrUpdateRoleInput input);

        /// <summary>
        /// 更新角色
        /// </summary>
        Task UpdateAsync(CreateOrUpdateRoleInput input);

        /// <summary>
        /// 删除角色
        /// </summary>
        Task DeleteAsync(EntityDto<int> input);

        /// <summary>
        /// 批量删除角色
        /// </summary>
        Task BatchDeleteAsync(List<int> input);

        /// <summary>
        /// 自定义检查角色输入逻辑错误
        /// </summary>
        /// <param name="output"></param>
        /// <returns></returns>
        Task<CustomerModelStateValidationDto> CheckErrorAsync(GetRoleForEditOutput output);

        #endregion

    }
}
