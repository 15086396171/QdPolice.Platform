/*
* 命名空间 :     Vickn.Platform.HandheldTerminals.AppWhiteLists.Dtos
* 类 名  称 :     AppWhiteListEditDto
* 版      本 :      v1.0.0.0
* 文 件  名 :     AppWhiteListEditDto.cs
* 描      述 :     应用白名单管理编辑Dto
* 创建时间 :     2018/2/5 15:11:39
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace Vickn.Platform.HandheldTerminals.AppWhiteLists.Dtos
{
    /// <summary>
    /// 应用白名单管理编辑Dto
    /// </summary>
    [AutoMap(typeof(AppWhiteList))]
    public class AppWhiteListEditDto
    {
	    /// <summary>
        ///   主键Id
        /// </summary>
        [DisplayName("主键Id")]
		public long? Id{get;set;}
        /// <summary>
        /// 应用名称
        /// </summary>
		[DisplayName("应用名称")]
        [Required]
        [MaxLength(64)]
        public string Name { get; set; }

        /// <summary>
        /// 包名
        /// </summary>
		[DisplayName("包名")]
        [Required]
        [MaxLength(64)]
        public string PackageName { get; set; }

        /// <summary>
        /// 文件
        /// </summary>
		[DisplayName("文件")]
        [Required]
        [MaxLength(128)]
        public string Src { get; set; }

        /// <summary>
        /// 版本号
        /// </summary>
        [DisplayName("版本号")]
        [Required]
        [MaxLength(128)]
        public string Version { get; set; }

    }
}
