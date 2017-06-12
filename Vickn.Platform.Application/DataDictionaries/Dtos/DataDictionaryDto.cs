/*
* 命名空间 :     Vickn.Platform.DataDictionaries.Dtos
* 类 名  称 :     GetDataDictionaryInput
* 版      本 :      v1.0.0.0
* 文 件  名 :     GetDataDictionaryInput.cs
* 描      述 :     数据字典管理Dto
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
    /// 数据字典管理Dto
    /// </summary>
    [AutoMap(typeof(DataDictionary))]
    public class DataDictionaryDto : EntityDto<int>
    {
        /// <summary>
        /// 键名
        /// </summary>
		[DisplayName("键名")]
        public string Key { get; set; }

        /// <summary>
        /// 显示名
        /// </summary>
		[DisplayName("显示名")]
        public string DisplayName { get; set; }

    }
}
