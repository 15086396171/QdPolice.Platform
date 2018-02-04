/*
* 命名空间 :     Vickn.Platform.HandheldTerminals.Devices.Dtos
* 类 名  称 :     GetDeviceInput
* 版      本 :      v1.0.0.0
* 文 件  名 :     GetDeviceInput.cs
* 描      述 :     设备管理Dto
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
    /// 设备管理Dto
    /// </summary>
    [AutoMap(typeof(Device))]
    public class DeviceDto : EntityDto<long>
    {
        public UserListDto User { get; set; }

        /// <summary>
        /// IMEI
        /// </summary>
		[DisplayName("IMEI")]
        public string Imei { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
		[DisplayName("编号")]
        public string No { get; set; }

        /// <summary>
        /// 电量
        /// </summary>
		[DisplayName("电量")]
        public string Battery { get; set; }

    }
}
