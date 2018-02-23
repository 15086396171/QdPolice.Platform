/*
* 命名空间 :     Vickn.Platform.PrivatePhoneWhites.Dtos
* 类 名  称 :     PrivatePhoneWhiteForEdit
* 版      本 :      v1.0.0.0
* 文 件  名 :     PrivatePhoneWhiteForEdit.cs
* 描      述 :     用于获取添加或编辑 个人白名单管理时使用的Dto
* 创建时间 :     2018/2/23 14:15:13
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace Vickn.Platform.PrivatePhoneWhites.Dtos
{
    /// <summary>
    /// 用于获取添加或编辑 个人白名单管理时使用的Dto
    /// </summary>
    public class PrivatePhoneWhiteForEdit
    {
		public PrivatePhoneWhiteEditDto PrivatePhoneWhiteEditDto { get; set; } 
    }
}
