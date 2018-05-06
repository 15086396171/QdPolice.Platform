/*
* 命名空间 :     Vickn.Platform.PbManagement.PbTitles
* 类 名  称 :      IPbTitleAppService 
* 版      本 :      v1.0.0.0
* 文 件  名 :     IPbTitleAppService.cs
* 描      述 :     排班标题服务接口
* 创建时间 :     2018/5/6 14:40:38
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Vickn.Platform.PbManagement.PbTitles.Dtos;
using Vickn.Platform.Dtos;

namespace Vickn.Platform.PbManagement.PbTitles
{
     /// <summary>
    /// 排班标题服务接口
    /// </summary>
    public interface IPbTitleAppService : IApplicationService
    {
        #region 排班标题管理

		/// <summary>
        /// 根据查询条件获取排班标题分页列表
        /// </summary>
        Task<PagedResultDto<PbTitleDto>> GetPagedAsync(GetPbTitleInput input);

		 /// <summary>
        /// 通过指定id获取排班标题Dto信息
        /// </summary>
        Task<PbTitleDto> GetByIdAsync(EntityDto<int> input);

        /// <summary>
        /// 通过Id获取排班标题信息进行编辑或修改
        /// Id为空时返回新对象 
        /// </summary>
        Task<PbTitleForEdit> GetForEditAsync(NullableIdDto<int> input);

        /// <summary>
        /// 新增或更改排班标题
        /// </summary>
        Task CreateOrUpdateAsync(PbTitleForEdit input);

        /// <summary>
        /// 新增排班标题
        /// </summary>
        Task<PbTitleForEdit> CreateAsync(PbTitleForEdit input);

        /// <summary>
        /// 修改排班标题
        /// </summary>
        Task UpdateAsync(PbTitleForEdit input);

        /// <summary>
        /// 删除排班标题
        /// </summary>
        Task DeleteAsync(EntityDto<int> input);

        /// <summary>
        /// 批量删除排班标题
        /// </summary>
        Task BatchDeleteAsync(List<int> input);

        /// <summary>
        /// 自定义检查排班标题输入逻辑错误
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<CustomerModelStateValidationDto> CheckErrorAsync(PbTitleForEdit input);

        #endregion

    }
}
