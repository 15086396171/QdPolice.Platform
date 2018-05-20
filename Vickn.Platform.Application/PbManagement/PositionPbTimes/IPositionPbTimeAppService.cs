/*
* 命名空间 :     Vickn.Platform.PbManagement.PositionPbTimes
* 类 名  称 :      IPositionPbTimeAppService 
* 版      本 :      v1.0.0.0
* 文 件  名 :     IPositionPbTimeAppService.cs
* 描      述 :     当天上下班时间服务接口
* 创建时间 :     2018/5/8 13:47:37
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Vickn.Platform.PbManagement.PositionPbTimes.Dtos;
using Vickn.Platform.Dtos;

namespace Vickn.Platform.PbManagement.PositionPbTimes
{
     /// <summary>
    /// 当天上下班时间服务接口
    /// </summary>
    public interface IPositionPbTimeAppService : IApplicationService
    {
        #region 当天上下班时间管理



		/// <summary>
        /// 根据查询条件获取当天上下班时间分页列表
        /// </summary>
        Task<PagedResultDto<PositionPbTimeDto>> GetPagedAsync(GetPositionPbTimeInput input);

		 /// <summary>
        /// 通过指定id获取当天上下班时间Dto信息
        /// </summary>
        Task<PositionPbTimeDto> GetByIdAsync(EntityDto<long> input);

        /// <summary>
        /// 通过Id获取当天上下班时间信息进行编辑或修改
        /// Id为空时返回新对象 
        /// </summary>
        Task<PositionPbTimeForEdit> GetForEditAsync(NullableIdDto<long> input);

        /// <summary>
        /// 新增或更改当天上下班时间
        /// </summary>
        Task CreateOrUpdateAsync(PositionPbTimeForEdit input);

        /// <summary>
        /// 新增当天上下班时间
        /// </summary>
        Task<PositionPbTimeForEdit> CreateAsync(PositionPbTimeForEdit input);

        /// <summary>
        /// 修改当天上下班时间
        /// </summary>
        Task UpdateAsync(PositionPbTimeForEdit input);

        /// <summary>
        /// 删除当天上下班时间
        /// </summary>
        Task DeleteAsync(EntityDto<long> input);

        /// <summary>
        /// 批量删除当天上下班时间
        /// </summary>
        Task BatchDeleteAsync(List<long> input);

        /// <summary>
        /// 自定义检查当天上下班时间输入逻辑错误
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<CustomerModelStateValidationDto> CheckErrorAsync(PositionPbTimeForEdit input);


        /// <summary>
        /// 根据用户查询获取当月值班列表
        /// </summary>
        Task<List<PositionPbTimeListDto>> GetAllAsync();

        /// <summary>
        /// 查询获取当月除发起人外所有未值班列表
        /// </summary>
        Task<List<PositionPbTimeListDto>> GetAllForUserDutyAsync();

        /// <summary>
        /// 查询所选日期未值班列表
        /// </summary>
        Task<List<PositionPbUserTimeListDto>> GetUserAllForDutyAsync(GetPositionUserPbTimeListDto input);

        #endregion


        #region 警务通
        /// <summary>
        /// app根据用户查询获取当月值班列表
        /// </summary>
        Task<List<AppPositionPbTimeDto>> AppGetAllAsync();


        /// <summary>
        /// app根据用户部门查询获取当月值班列表详情
        /// </summary>
        Task<List<AppPositionPbTimeDetailDto>> AppGetAllDetailAsync(AppGetPositionPbDto input);
        #endregion
    }
}
