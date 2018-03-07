/*
* 命名空间 :     Vickn.Platform.PrivatePhoneWhites.Dtos
* 类 名  称 :     PrivatePhoneWhiteEditDto
* 版      本 :      v1.0.0.0
* 文 件  名 :     PrivatePhoneWhiteEditDto.cs
* 描      述 :     个人白名单管理编辑Dto
* 创建时间 :     2018/2/23 14:15:12
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Vickn.PlatfForm.Utils;

namespace Vickn.Platform.PrivatePhoneWhites.Dtos
{
    /// <summary>
    /// 个人白名单管理编辑Dto
    /// </summary>
    [AutoMap(typeof(PrivatePhoneWhite))]
    public class PrivatePhoneWhiteEditDto
    {
	    /// <summary>
        ///   主键Id
        /// </summary>
        [DisplayName("主键Id")]
		public long? Id{get;set;}
        /// <summary>
        /// 姓名
        /// </summary>
		[DisplayName("姓名")]
        [Required]
        [MaxLength(16)]
        public string Name { get; set; }

        /// <summary>
        /// 电话号码
        /// </summary>
		[DisplayName("电话号码")]
        [Required]
        [MaxLength(16)]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// 所属人Id
        /// </summary>
		[DisplayName("所属人Id")]
        public long UserId { get; set; }

    }
}
