/*
* 命名空间 :     Vickn.Platform.HandheldTerminals.Devices.Dtos
* 类 名  称 :     DeviceForEdit
* 版      本 :      v1.0.0.0
* 文 件  名 :     DeviceForEdit.cs
* 描      述 :     用于获取添加或编辑 设备管理时使用的Dto
* 创建时间 :     2018/2/4 16:27:05
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace Vickn.Platform.HandheldTerminals.Devices.Dtos
{
    /// <summary>
    /// 用于获取添加或编辑 设备管理时使用的Dto
    /// </summary>
    public class DeviceForEdit
    {
		public DeviceEditDto DeviceEditDto { get; set; } 
    }
}
