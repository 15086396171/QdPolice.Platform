/*
* 命名空间 :     Vickn.Platform.Zero.UserPositions.Dtos
* 类 名  称 :     UserPositionForEdit
* 版      本 :      v1.0.0.0
* 文 件  名 :     UserPositionForEdit.cs
* 描      述 :     用于获取添加或编辑 职位信息管理时使用的Dto
* 创建时间 :     2018/5/16 9:57:53
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace Vickn.Platform.Zero.UserPositions.Dtos
{
    /// <summary>
    /// 用于获取添加或编辑 职位信息管理时使用的Dto
    /// </summary>
    public class UserPositionForEdit
    {
		public UserPositionEditDto UserPositionEditDto { get; set; } 
    }
}
