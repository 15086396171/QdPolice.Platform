/*
* 命名空间 :     Vickn.Platform.PbManagement.PositionPbMaps.Dtos
* 类 名  称 :     PositionPbMapForEdit
* 版      本 :      v1.0.0.0
* 文 件  名 :     PositionPbMapForEdit.cs
* 描      述 :     用于获取添加或编辑 排班人员管理时使用的Dto
* 创建时间 :     2018/5/7 10:29:08
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace Vickn.Platform.PbManagement.PositionPbMaps.Dtos
{
    /// <summary>
    /// 用于获取添加或编辑 排班人员管理时使用的Dto
    /// </summary>
    public class PositionPbMapForEdit
    {
		public PositionPbMapEditDto PositionPbMapEditDto { get; set; } 
    }
}
