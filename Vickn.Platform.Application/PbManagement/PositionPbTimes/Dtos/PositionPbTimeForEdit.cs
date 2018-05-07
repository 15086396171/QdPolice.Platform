/*
* 命名空间 :     Vickn.Platform.PbManagement.PositionPbTimes.Dtos
* 类 名  称 :     PositionPbTimeForEdit
* 版      本 :      v1.0.0.0
* 文 件  名 :     PositionPbTimeForEdit.cs
* 描      述 :     用于获取添加或编辑 当天上下班时间管理时使用的Dto
* 创建时间 :     2018/5/6 17:23:53
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace Vickn.Platform.PbManagement.PositionPbTimes.Dtos
{
    /// <summary>
    /// 用于获取添加或编辑 当天上下班时间管理时使用的Dto
    /// </summary>
    public class PositionPbTimeForEdit
    {
		public PositionPbTimeEditDto PositionPbTimeEditDtos { get; set; } 
    }
}
