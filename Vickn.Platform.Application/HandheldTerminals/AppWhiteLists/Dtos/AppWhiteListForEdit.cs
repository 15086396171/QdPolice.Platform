/*
* 命名空间 :     Vickn.Platform.HandheldTerminals.AppWhiteLists.Dtos
* 类 名  称 :     AppWhiteListForEdit
* 版      本 :      v1.0.0.0
* 文 件  名 :     AppWhiteListForEdit.cs
* 描      述 :     用于获取添加或编辑 应用白名单管理时使用的Dto
* 创建时间 :     2018/2/5 15:11:40
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
    /// 用于获取添加或编辑 应用白名单管理时使用的Dto
    /// </summary>
    public class AppWhiteListForEdit
    {
		public AppWhiteListEditDto AppWhiteListEditDto { get; set; } 
    }
}
