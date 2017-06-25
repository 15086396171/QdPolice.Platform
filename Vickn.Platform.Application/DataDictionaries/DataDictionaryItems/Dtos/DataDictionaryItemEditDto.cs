/*
* 命名空间 :     Vickn.Platform.DataDictionaries.Dtos
* 类 名  称 :     DataDictionaryItemEditDto
* 版      本 :      v1.0.0.0
* 文 件  名 :     DataDictionaryItemEditDto.cs
* 描      述 :     数据字典项管理编辑Dto
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
    /// 数据字典项管理编辑Dto
    /// </summary>
    [AutoMap(typeof(DataDictionaryItem))]
    public class DataDictionaryItemEditDto
    {
	    /// <summary>
        ///   主键Id
        /// </summary>
        [DisplayName("主键Id")]
		public int? Id{get;set;}
        /// <summary>
        /// 值
        /// </summary>
		[DisplayName("值")]
        [Required]
        [MaxLength(32)]
        public string Value { get; set; }

        /// <summary>
        /// 显示名
        /// </summary>
        [DisplayName("显示名")]
        [MaxLength(32)]
        public string DisplayName { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
        [DisplayName("编号")]
        public string Number { get; set; }

        /// <summary>
        /// 上级编号
        /// </summary>
        [DisplayName("上级编号")]
        public string ParentNo { get; set; }

        /// <summary>
        /// 扩展字段，按*分隔
        /// </summary>
        [DisplayName("扩展字段")]
        public string Extend { get; set; }

        /// <summary>
        /// 键Id
        /// </summary>
		[DisplayName("键Id")]
        [Required]
        public int DataDictionaryId { get; set; }

    }
}
