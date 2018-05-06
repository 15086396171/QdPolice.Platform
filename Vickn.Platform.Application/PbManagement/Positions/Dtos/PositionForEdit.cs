/*
* 命名空间 :     Vickn.Platform.PbManagement.Positions.Dtos
* 类 名  称 :     PositionForEdit
* 版      本 :      v1.0.0.0
* 文 件  名 :     PositionForEdit.cs
* 描      述 :     用于获取添加或编辑 岗位管理时使用的Dto
* 创建时间 :     2018/5/6 14:16:42
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace Vickn.Platform.PbManagement.Positions.Dtos
{
    /// <summary>
    /// 用于获取添加或编辑 岗位管理时使用的Dto
    /// </summary>
    public class PositionForEdit
    {
		public PositionEditDto PositionEditDto { get; set; } 
    }
}
