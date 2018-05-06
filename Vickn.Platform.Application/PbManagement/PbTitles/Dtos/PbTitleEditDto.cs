/*
* 命名空间 :     Vickn.Platform.PbManagement.PbTitles.Dtos
* 类 名  称 :     PbTitleEditDto
* 版      本 :      v1.0.0.0
* 文 件  名 :     PbTitleEditDto.cs
* 描      述 :     排班标题管理编辑Dto
* 创建时间 :     2018/5/6 14:40:36
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
    /// 排班标题管理编辑Dto
    /// </summary>
    [AutoMap(typeof(PbTitle))]
    public class PbTitleEditDto
    {
	    /// <summary>
        ///   主键Id
        /// </summary>
        [DisplayName("主键Id")]
		public int? Id{get;set;}
        /// <summary>
        /// 排班标题
        /// </summary>
		[DisplayName("排班标题")]
        [Required]
        [MaxLength(64)]
        public string Title { get; set; }

        /// <summary>
        /// 排班时间
        /// </summary>
		[DisplayName("排班时间")]
        [Required]
        public DateTime Month { get; set; }

    }
}
