/*
* 命名空间 :     Vickn.Platform.PbManagement.PositionPbs
* 类 名  称 :      IPositionPbAppService 
* 版      本 :      v1.0.0.0
* 文 件  名 :     IPositionPbAppService.cs
* 描      述 :     单个岗位下排班时间服务接口
* 创建时间 :     2018/5/6 17:14:53
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Vickn.Platform.PbManagement.PositionPbs.Dtos;
using Vickn.Platform.Dtos;

namespace Vickn.Platform.PbManagement.PositionPbs
{
     /// <summary>
    /// 单个岗位下排班时间服务接口
    /// </summary>
    public interface IPositionPbAppService : IApplicationService
    {
        #region 单个岗位下排班时间管理

		/// <summary>
        /// 根据查询条件获取单个岗位下排班时间分页列表
        /// </summary>
        Task<PagedResultDto<PositionPbDto>> GetPagedAsync(GetPositionPbInput input);

		 /// <summary>
        /// 通过指定id获取单个岗位下排班时间Dto信息
        /// </summary>
        Task<PositionPbDto> GetByIdAsync(EntityDto<int> input);

        /// <summary>
        /// 通过Id获取单个岗位下排班时间信息进行编辑或修改
        /// Id为空时返回新对象 
        /// </summary>
        Task<PositionPbForEdit> GetForEditAsync(NullableIdDto<int> input);

        /// <summary>
        /// 新增或更改单个岗位下排班时间
        /// </summary>
        Task CreateOrUpdateAsync(PositionPbForEdit input);

        /// <summary>
        /// 新增单个岗位下排班时间
        /// </summary>
        Task<PositionPbForEdit> CreateAsync(PositionPbForEdit input);

        /// <summary>
        /// 修改单个岗位下排班时间
        /// </summary>
        Task UpdateAsync(PositionPbForEdit input);

        /// <summary>
        /// 删除单个岗位下排班时间
        /// </summary>
        Task DeleteAsync(EntityDto<int> input);

        /// <summary>
        /// 批量删除单个岗位下排班时间
        /// </summary>
        Task BatchDeleteAsync(List<int> input);

        /// <summary>
        /// 自定义检查单个岗位下排班时间输入逻辑错误
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<CustomerModelStateValidationDto> CheckErrorAsync(PositionPbForEdit input);

        #endregion

    }
}
