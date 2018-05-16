/*
* 命名空间 :     Vickn.Platform.Zero.UserPositions.Dtos
* 类 名  称 :     GetUserPositionInput
* 版      本 :      v1.0.0.0
* 文 件  名 :     GetUserPositionInput.cs
* 描      述 :     职位信息管理Dto
* 创建时间 :     2018/5/16 9:57:52
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
    /// 职位信息管理Dto
    /// </summary>
    [AutoMap(typeof(UserPosition))]
    public class UserPositionDto : EntityDto<long>
    {
        /// <summary>
        /// 职位名称
        /// </summary>
		[DisplayName("职位名称")]
        public string PositionName { get; set; }

        /// <summary>
        /// 职位等级
        /// </summary>
		[DisplayName("职位等级")]
        public int RankOfPosition { get; set; }

    }
}
