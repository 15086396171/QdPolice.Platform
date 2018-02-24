/*
* 命名空间 :     Vickn.Platform.Announcements.Dtos
* 类 名  称 :     AnnouncementForEdit
* 版      本 :      v1.0.0.0
* 文 件  名 :     AnnouncementForEdit.cs
* 描      述 :     用于获取添加或编辑 通知公告管理时使用的Dto
* 创建时间 :     2018/2/24 11:43:00
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
    /// 用于获取添加或编辑 通知公告管理时使用的Dto
    /// </summary>
    public class AnnouncementForEdit
    {
		public AnnouncementEditDto AnnouncementEditDto { get; set; } 
    }
}
