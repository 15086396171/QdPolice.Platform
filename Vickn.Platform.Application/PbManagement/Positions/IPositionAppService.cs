/*
* 命名空间 :     Vickn.Platform.PbManagement.Positions
* 类 名  称 :      IPositionAppService 
* 版      本 :      v1.0.0.0
* 文 件  名 :     IPositionAppService.cs
* 描      述 :     岗位服务接口
* 创建时间 :     2018/5/6 14:16:43
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Vickn.Platform.PbManagement.Positions.Dtos;
using Vickn.Platform.Dtos;

namespace Vickn.Platform.PbManagement.Positions
{
     /// <summary>
    /// 岗位服务接口
    /// </summary>
    public interface IPositionAppService : IApplicationService
    {
        #region 岗位管理

		/// <summary>
        /// 根据查询条件获取岗位分页列表
        /// </summary>
        Task<PagedResultDto<PositionDto>> GetPagedAsync(GetPositionInput input);

		 /// <summary>
        /// 通过指定id获取岗位Dto信息
        /// </summary>
        Task<PositionDto> GetByIdAsync(EntityDto<int> input);

        /// <summary>
        /// 通过Id获取岗位信息进行编辑或修改
        /// Id为空时返回新对象 
        /// </summary>
        Task<PositionForEdit> GetForEditAsync(NullableIdDto<int> input);

        /// <summary>
        /// 新增或更改岗位
        /// </summary>
        Task CreateOrUpdateAsync(PositionForEdit input);

        /// <summary>
        /// 新增岗位
        /// </summary>
        Task<PositionForEdit> CreateAsync(PositionForEdit input);

        /// <summary>
        /// 修改岗位
        /// </summary>
        Task UpdateAsync(PositionForEdit input);

        /// <summary>
        /// 删除岗位
        /// </summary>
        Task DeleteAsync(EntityDto<int> input);

        /// <summary>
        /// 批量删除岗位
        /// </summary>
        Task BatchDeleteAsync(List<int> input);

        /// <summary>
        /// 自定义检查岗位输入逻辑错误
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<CustomerModelStateValidationDto> CheckErrorAsync(PositionForEdit input);

        #endregion

    }
}
