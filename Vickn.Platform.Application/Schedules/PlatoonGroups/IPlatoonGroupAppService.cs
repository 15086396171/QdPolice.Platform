/*
* 命名空间 :     Vickn.Platform.Schedules.PlatoonGroups
* 类 名  称 :      IPlatoonGroupAppService 
* 版      本 :      v1.0.0.0
* 文 件  名 :     IPlatoonGroupAppService.cs
* 描      述 :     排班组服务接口
* 创建时间 :     2018/5/4 15:19:53
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Vickn.Platform.Schedules.PlatoonGroups.Dtos;
using Vickn.Platform.Dtos;

namespace Vickn.Platform.Schedules.PlatoonGroups
{
     /// <summary>
    /// 排班组服务接口
    /// </summary>
    public interface IPlatoonGroupAppService : IApplicationService
    {
        #region 排班组管理

		/// <summary>
        /// 根据查询条件获取排班组分页列表
        /// </summary>
        Task<PagedResultDto<PlatoonGroupDto>> GetPagedAsync(GetPlatoonGroupInput input);

		 /// <summary>
        /// 通过指定id获取排班组Dto信息
        /// </summary>
        Task<PlatoonGroupDto> GetByIdAsync(EntityDto<long> input);

        /// <summary>
        /// 通过Id获取排班组信息进行编辑或修改
        /// Id为空时返回新对象 
        /// </summary>
        Task<PlatoonGroupForEdit> GetForEditAsync(NullableIdDto<long> input);

        /// <summary>
        /// 新增或更改排班组
        /// </summary>
        Task CreateOrUpdateAsync(PlatoonGroupForEdit input);

        /// <summary>
        /// 新增排班组
        /// </summary>
        Task<PlatoonGroupForEdit> CreateAsync(PlatoonGroupForEdit input);

        /// <summary>
        /// 修改排班组
        /// </summary>
        Task UpdateAsync(PlatoonGroupForEdit input);

        /// <summary>
        /// 删除排班组
        /// </summary>
        Task DeleteAsync(EntityDto<long> input);

        /// <summary>
        /// 批量删除排班组
        /// </summary>
        Task BatchDeleteAsync(List<long> input);

        /// <summary>
        /// 自定义检查排班组输入逻辑错误
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<CustomerModelStateValidationDto> CheckErrorAsync(PlatoonGroupForEdit input);

        #endregion

    }
}
