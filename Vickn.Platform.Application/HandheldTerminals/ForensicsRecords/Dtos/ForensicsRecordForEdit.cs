/*
* 命名空间 :     Vickn.Platform.HandheldTerminals.Dtos
* 类 名  称 :     ForensicsRecordForEdit
* 版      本 :      v1.0.0.0
* 文 件  名 :     ForensicsRecordForEdit.cs
* 描      述 :     用于获取添加或编辑 取证记录管理时使用的Dto
* 创建时间 :     2018/2/5 17:40:09
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace Vickn.Platform.HandheldTerminals.Dtos
{
    /// <summary>
    /// 用于获取添加或编辑 取证记录管理时使用的Dto
    /// </summary>
    public class ForensicsRecordForEdit
    {
		public ForensicsRecordEditDto ForensicsRecordEditDto { get; set; } 
    }
}
