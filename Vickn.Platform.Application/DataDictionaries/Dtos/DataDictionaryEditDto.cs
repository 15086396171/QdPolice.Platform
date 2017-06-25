/*
* 命名空间 :     Vickn.Platform.DataDictionaries.Dtos
* 类 名  称 :     DataDictionaryEditDto
* 版      本 :      v1.0.0.0
* 文 件  名 :     DataDictionaryEditDto.cs
* 描      述 :     数据字典管理编辑Dto
* 创建时间 :     2017/6/12 16:41:30
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
    /// 数据字典管理编辑Dto
    /// </summary>
    [AutoMap(typeof(DataDictionary))]
    public class DataDictionaryEditDto
    {
        /// <summary>
        ///   主键Id
        /// </summary>
        [DisplayName("主键Id")]
        public int? Id { get; set; }
        /// <summary>
        /// 键名
        /// </summary>
		[DisplayName("键名")]
        [Required]
        [MaxLength(16)]
        public string Key { get; set; }

        /// <summary>
        /// 显示名
        /// </summary>
		[DisplayName("名称")]
        [Required]
        [MaxLength(16)]
        public string DisplayName { get; set; }

    }
}
