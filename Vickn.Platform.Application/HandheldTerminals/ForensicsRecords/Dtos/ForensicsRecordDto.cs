/*
* 命名空间 :     Vickn.Platform.HandheldTerminals.Dtos
* 类 名  称 :     GetForensicsRecordInput
* 版      本 :      v1.0.0.0
* 文 件  名 :     GetForensicsRecordInput.cs
* 描      述 :     取证记录管理Dto
* 创建时间 :     2018/2/5 17:40:09
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace Vickn.Platform.HandheldTerminals.Dtos
{
    /// <summary>
    /// 取证记录管理Dto
    /// </summary>
    [AutoMap(typeof(ForensicsRecord))]
    public class ForensicsRecordDto : EntityDto<long>
    {
        /// <summary>
        /// 路径
        /// </summary>
		[DisplayName("路径")]
        public string Src { get; set; }

        /// <summary>
        /// 模式
        /// </summary>
		[DisplayName("模式")]
        public string Mode { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
		[DisplayName("描述")]
        public string Des { get; set; }

        /// <summary>
        /// 文件类型
        /// </summary>
		[DisplayName("文件类型")]
        public ForensicsRecordType ForensicsRecordType { get; set; }

        public long DeviceId { get; set; }

    }
}
