/*
* 命名空间 :     Vickn.Platform.PbManagement.PbTitles.Dtos
* 类 名  称 :     PbTitleForEdit
* 版      本 :      v1.0.0.0
* 文 件  名 :     PbTitleForEdit.cs
* 描      述 :     用于获取添加或编辑 排班标题管理时使用的Dto
* 创建时间 :     2018/5/6 14:40:38
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace Vickn.Platform.PbManagement.PbTitles.Dtos
{
    /// <summary>
    /// 用于获取添加或编辑 排班标题管理时使用的Dto
    /// </summary>
    public class PbTitleForEdit
    {
		public PbTitleEditDto PbTitleEditDto { get; set; } 
    }
}
