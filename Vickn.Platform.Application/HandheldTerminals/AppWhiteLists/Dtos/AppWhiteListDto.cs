/*
* 命名空间 :     Vickn.Platform.HandheldTerminals.AppWhiteLists.Dtos
* 类 名  称 :     GetAppWhiteListInput
* 版      本 :      v1.0.0.0
* 文 件  名 :     GetAppWhiteListInput.cs
* 描      述 :     应用白名单管理Dto
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
    /// 应用白名单管理Dto
    /// </summary>
    [AutoMap(typeof(AppWhiteList))]
    public class AppWhiteListDto : EntityDto<long>
    {
        /// <summary>
        /// 应用名称
        /// </summary>
		[DisplayName("应用名称")]
        public string Name { get; set; }

        /// <summary>
        /// 包名
        /// </summary>
		[DisplayName("包名")]
        public string PackageName { get; set; }

        /// <summary>
        /// 文件
        /// </summary>
		[DisplayName("文件")]
        public string Src { get; set; }

        /// <summary>
        /// 版本号
        /// </summary>
        public string Version { get; set; }

    }
}
