/*
* 命名空间 :     Vickn.Platform.PbManagement.PositionPbs.Dtos
* 类 名  称 :     PositionPbForEdit
* 版      本 :      v1.0.0.0
* 文 件  名 :     PositionPbForEdit.cs
* 描      述 :     用于获取添加或编辑 单个岗位下排班时间管理时使用的Dto
* 创建时间 :     2018/5/6 17:14:53
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace Vickn.Platform.PbManagement.PositionPbs.Dtos
{
    /// <summary>
    /// 用于获取添加或编辑 单个岗位下排班时间管理时使用的Dto
    /// </summary>
    public class PositionPbForEdit
    {
		public PositionPbEditDto PositionPbEditDto { get; set; } 
    }
}
