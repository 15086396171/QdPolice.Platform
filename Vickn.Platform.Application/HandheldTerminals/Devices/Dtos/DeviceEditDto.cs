/*
* 命名空间 :     Vickn.Platform.HandheldTerminals.Devices.Dtos
* 类 名  称 :     DeviceEditDto
* 版      本 :      v1.0.0.0
* 文 件  名 :     DeviceEditDto.cs
* 描      述 :     设备管理编辑Dto
* 创建时间 :     2018/2/4 16:27:04
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Vickn.Platform.Users.Dtos;

namespace Vickn.Platform.HandheldTerminals.Devices.Dtos
{
    /// <summary>
    /// 设备管理编辑Dto
    /// </summary>
    [AutoMap(typeof(Device))]
    public class DeviceEditDto
    {
	    /// <summary>
        ///   主键Id
        /// </summary>
        [DisplayName("主键Id")]
		public long? Id{get;set;}
        public UserListDto User { get; set; }

        /// <summary>
        /// IMEI
        /// </summary>
		[DisplayName("IMEI")]
        [Required]
        [MaxLength(32)]
        public string Imei { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
		[DisplayName("编号")]
        [MaxLength(16)]
        public string No { get; set; }

        /// <summary>
        /// 电量
        /// </summary>
		[DisplayName("电量")]
        [MaxLength(16)]
        public string Battery { get; set; }

    }
}
