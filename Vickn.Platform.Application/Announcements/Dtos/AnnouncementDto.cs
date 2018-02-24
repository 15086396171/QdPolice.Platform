/*
* 命名空间 :     Vickn.Platform.Announcements.Dtos
* 类 名  称 :     GetAnnouncementInput
* 版      本 :      v1.0.0.0
* 文 件  名 :     GetAnnouncementInput.cs
* 描      述 :     通知公告管理Dto
* 创建时间 :     2018/2/24 11:42:59
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace Vickn.Platform.Announcements.Dtos
{
    /// <summary>
    /// 通知公告管理Dto
    /// </summary>
    [AutoMap(typeof(Announcement))]
    public class AnnouncementDto : EntityDto<long>
    {
        /// <summary>
        /// 标题
        /// </summary>
		[DisplayName("标题")]
        public string Title { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
		[DisplayName("内容")]
        public string Content { get; set; }

    }
}
