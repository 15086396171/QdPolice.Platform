/*
* 命名空间 :     Vickn.Platform.PbManagement.Positions.Dtos
* 类 名  称 :     GetPositionInput
* 版      本 :      v1.0.0.0
* 文 件  名 :     GetPositionInput.cs
* 描      述 :     岗位管理Dto
* 创建时间 :     2018/5/6 14:16:42
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace Vickn.Platform.PbManagement.Positions.Dtos
{
    /// <summary>
    /// 岗位管理Dto
    /// </summary>
    [AutoMap(typeof(Position))]
    public class PositionDto : EntityDto<int>
    {
        /// <summary>
        /// 岗位名称
        /// </summary>
		[DisplayName("岗位名称")]
        public string Name { get; set; }

    }
}
