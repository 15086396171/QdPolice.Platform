﻿/*
* 命名空间 :     Vickn.Platform.DataDictionaries.Dtos
* 类 名  称 :     DataDictionaryItemForEdit
* 版      本 :      v1.0.0.0
* 文 件  名 :     DataDictionaryItemForEdit.cs
* 描      述 :     用于获取添加或编辑 数据字典项管理时使用的Dto
* 创建时间 :     2017/6/12 16:57:19
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace Vickn.Platform.DataDictionaries.Dtos
{
    /// <summary>
    /// 用于获取添加或编辑 数据字典项管理时使用的Dto
    /// </summary>
    public class DataDictionaryItemForEdit
    {
		public DataDictionaryItemEditDto DataDictionaryItemEditDto { get; set; } 
    }
}
