/*
* 命名空间 :     Vickn.Platform.Schedules.SchedulingPosts
* 类 名  称 :      ISchedulingPostAppService 
* 版      本 :      v1.0.0.0
* 文 件  名 :     ISchedulingPostAppService.cs
* 描      述 :     岗位设置服务接口
* 创建时间 :     2018/5/3 15:40:50
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Vickn.Platform.Schedules.SchedulingPosts.Dtos;
using Vickn.Platform.Dtos;

namespace Vickn.Platform.Schedules.SchedulingPosts
{
     /// <summary>
    /// 岗位设置服务接口
    /// </summary>
    public interface ISchedulingPostAppService : IApplicationService
    {
        #region 岗位设置管理

		/// <summary>
        /// 根据查询条件获取岗位设置分页列表
        /// </summary>
        Task<PagedResultDto<SchedulingPostDto>> GetPagedAsync(GetSchedulingPostInput input);

		 /// <summary>
        /// 通过指定id获取岗位设置Dto信息
        /// </summary>
        Task<SchedulingPostDto> GetByIdAsync(EntityDto<long> input);

        /// <summary>
        /// 通过Id获取岗位设置信息进行编辑或修改
        /// Id为空时返回新对象 
        /// </summary>
        Task<SchedulingPostForEdit> GetForEditAsync(NullableIdDto<long> input);

        /// <summary>
        /// 新增或更改岗位设置
        /// </summary>
        Task CreateOrUpdateAsync(SchedulingPostForEdit input);

        /// <summary>
        /// 新增岗位设置
        /// </summary>
        Task<SchedulingPostForEdit> CreateAsync(SchedulingPostForEdit input);

        /// <summary>
        /// 修改岗位设置
        /// </summary>
        Task UpdateAsync(SchedulingPostForEdit input);

        /// <summary>
        /// 删除岗位设置
        /// </summary>
        Task DeleteAsync(EntityDto<long> input);

        /// <summary>
        /// 批量删除岗位设置
        /// </summary>
        Task BatchDeleteAsync(List<long> input);

        /// <summary>
        /// 自定义检查岗位设置输入逻辑错误
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<CustomerModelStateValidationDto> CheckErrorAsync(SchedulingPostForEdit input);

        #endregion

    }
}
