/*
* 命名空间 :     Vickn.Platform.Schedules.PlatoonGroups.Dtos
* 类 名  称 :     PlatoonGroupForEdit
* 版      本 :      v1.0.0.0
* 文 件  名 :     PlatoonGroupForEdit.cs
* 描      述 :     用于获取添加或编辑 排班组管理时使用的Dto
* 创建时间 :     2018/5/3 17:22:53
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace Vickn.Platform.Schedules.PlatoonGroups.Dtos
{
    /// <summary>
    /// 用于获取添加或编辑 排班组管理时使用的Dto
    /// </summary>
    public class PlatoonGroupForEdit
    {
		public PlatoonGroupEditDto PlatoonGroupEditDto { get; set; } 
    }
}
