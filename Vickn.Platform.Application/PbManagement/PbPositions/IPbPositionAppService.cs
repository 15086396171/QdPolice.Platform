/*
* 命名空间 :     Vickn.Platform.PbManagement.PbPositions
* 类 名  称 :      IPbPositionAppService 
* 版      本 :      v1.0.0.0
* 文 件  名 :     IPbPositionAppService.cs
* 描      述 :     排班岗位服务接口
* 创建时间 :     2018/5/6 15:05:51
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Vickn.Platform.PbManagement.PbPositions.Dtos;
using Vickn.Platform.Dtos;

namespace Vickn.Platform.PbManagement.PbPositions
{
     /// <summary>
    /// 排班岗位服务接口
    /// </summary>
    public interface IPbPositionAppService : IApplicationService
    {
        #region 排班岗位管理

		/// <summary>
        /// 根据查询条件获取排班岗位分页列表
        /// </summary>
        Task<PagedResultDto<PbPositionDto>> GetPagedAsync(GetPbPositionInput input);

		 /// <summary>
        /// 通过指定id获取排班岗位Dto信息
        /// </summary>
        Task<PbPositionDto> GetByIdAsync(EntityDto<int> input);

   

        /// <summary>
        /// 通过Id获取排班岗位信息进行编辑或修改
        /// Id为空时返回新对象 
        /// </summary>
        Task<PbPositionForEdit> GetForEditAsync(NullableIdDto<int> input);

        /// <summary>
        /// 新增或更改排班岗位
        /// </summary>
        Task CreateOrUpdateAsync(PbPositionForEdit input);

        /// <summary>
        /// 新增排班岗位
        /// </summary>
        Task<PbPositionForEdit> CreateAsync(PbPositionForEdit input);

        /// <summary>
        /// 修改排班岗位
        /// </summary>
        Task UpdateAsync(PbPositionForEdit input);

        /// <summary>
        /// 删除排班岗位
        /// </summary>
        Task DeleteAsync(EntityDto<int> input);

        /// <summary>
        /// 批量删除排班岗位
        /// </summary>
        Task BatchDeleteAsync(List<int> input);

        /// <summary>
        /// 自定义检查排班岗位输入逻辑错误
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<CustomerModelStateValidationDto> CheckErrorAsync(PbPositionForEdit input);

        #endregion

    }
}
