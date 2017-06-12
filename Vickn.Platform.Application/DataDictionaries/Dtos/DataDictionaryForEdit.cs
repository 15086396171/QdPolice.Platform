/*
* 命名空间 :     Vickn.Platform.DataDictionaries.Dtos
* 类 名  称 :     DataDictionaryForEdit
* 版      本 :      v1.0.0.0
* 文 件  名 :     DataDictionaryForEdit.cs
* 描      述 :     用于获取添加或编辑 数据字典管理时使用的Dto
* 创建时间 :     2017/6/12 16:41:31
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
    /// 用于获取添加或编辑 数据字典管理时使用的Dto
    /// </summary>
    public class DataDictionaryForEdit
    {
		public DataDictionaryEditDto DataDictionaryEditDto { get; set; } 
    }
}
