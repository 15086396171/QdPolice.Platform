/*
* 命名空间 :     Vickn.Platform.Announcements.Dtos
* 类 名  称 :     AnnouncementEditDto
* 版      本 :      v1.0.0.0
* 文 件  名 :     AnnouncementEditDto.cs
* 描      述 :     通知公告管理编辑Dto
* 创建时间 :     2018/2/24 11:42:58
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace Vickn.Platform.Announcements.Dtos
{
    /// <summary>
    /// 通知公告管理编辑Dto
    /// </summary>
    [AutoMap(typeof(Announcement))]
    public class AnnouncementEditDto
    {
	    /// <summary>
        ///   主键Id
        /// </summary>
        [DisplayName("主键Id")]
		public long? Id{get;set;}
        /// <summary>
        /// 标题
        /// </summary>
		[DisplayName("标题")]
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
		[DisplayName("内容")]
        [Required]
        public string Content { get; set; }

        public virtual List<AnnouncementUserEditDto> AnnouncementUsers { get; set; }

    }
}
