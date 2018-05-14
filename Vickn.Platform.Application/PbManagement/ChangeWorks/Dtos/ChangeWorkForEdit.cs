/*
* 命名空间 :     Vickn.Platform.PbManagement.ChangWorks.Dtos
* 类 名  称 :     ChangeWorkForEdit
* 版      本 :      v1.0.0.0
* 文 件  名 :     ChangeWorkForEdit.cs
* 描      述 :     用于获取添加或编辑 换班管理时使用的Dto
* 创建时间 :     2018/5/14 9:16:04
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace Vickn.Platform.PbManagement.ChangeWorks.Dtos
{
    /// <summary>
    /// 用于获取添加或编辑 换班管理时使用的Dto
    /// </summary>
    public class ChangeWorkForEdit
    {
		public ChangeWorkEditDto ChangeWorkEditDto { get; set; } 
    }
}
