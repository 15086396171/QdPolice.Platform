/*
* 命名空间 :     Vickn.Platform.Announcements
* 类 名  称 :      IAnnouncementAppService 
* 版      本 :      v1.0.0.0
* 文 件  名 :     IAnnouncementAppService.cs
* 描      述 :     通知公告服务接口
* 创建时间 :     2018/2/24 11:43:01
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Vickn.Platform.Announcements.Dtos;
using Vickn.Platform.Dtos;

namespace Vickn.Platform.Announcements
{
     /// <summary>
    /// 通知公告服务接口
    /// </summary>
    public interface IAnnouncementAppService : IApplicationService
    {
        #region 通知公告管理

		/// <summary>
        /// 根据查询条件获取通知公告分页列表
        /// </summary>
        Task<PagedResultDto<AnnouncementDto>> GetPagedAsync(GetAnnouncementInput input);

		 /// <summary>
        /// 通过指定id获取通知公告Dto信息
        /// </summary>
        Task<AnnouncementDto> GetByIdAsync(EntityDto<long> input);

        /// <summary>
        /// 通过Id获取通知公告信息进行编辑或修改
        /// Id为空时返回新对象 
        /// </summary>
        Task<AnnouncementForEdit> GetForEditAsync(NullableIdDto<long> input);

        /// <summary>
        /// 新增或更改通知公告
        /// </summary>
        Task CreateOrUpdateAsync(AnnouncementForEdit input);

        /// <summary>
        /// 新增通知公告
        /// </summary>
        Task<AnnouncementForEdit> CreateAsync(AnnouncementForEdit input);

        /// <summary>
        /// 修改通知公告
        /// </summary>
        Task UpdateAsync(AnnouncementForEdit input);

        /// <summary>
        /// 删除通知公告
        /// </summary>
        Task DeleteAsync(EntityDto<long> input);

        /// <summary>
        /// 批量删除通知公告
        /// </summary>
        Task BatchDeleteAsync(List<long> input);

        /// <summary>
        /// 自定义检查通知公告输入逻辑错误
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<CustomerModelStateValidationDto> CheckErrorAsync(AnnouncementForEdit input);

        #endregion

    }
}
