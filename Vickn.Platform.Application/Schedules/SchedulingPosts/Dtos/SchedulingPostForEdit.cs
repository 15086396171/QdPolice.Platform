/*
* 命名空间 :     Vickn.Platform.Schedules.SchedulingPosts.Dtos
* 类 名  称 :     SchedulingPostForEdit
* 版      本 :      v1.0.0.0
* 文 件  名 :     SchedulingPostForEdit.cs
* 描      述 :     用于获取添加或编辑 岗位设置管理时使用的Dto
* 创建时间 :     2018/5/3 15:40:50
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace Vickn.Platform.Schedules.SchedulingPosts.Dtos
{
    /// <summary>
    /// 用于获取添加或编辑 岗位设置管理时使用的Dto
    /// </summary>
    public class SchedulingPostForEdit
    {
		public SchedulingPostEditDto SchedulingPostEditDto { get; set; } 
    }
}
