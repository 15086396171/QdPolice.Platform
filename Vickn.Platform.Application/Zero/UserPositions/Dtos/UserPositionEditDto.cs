/*
* 命名空间 :     Vickn.Platform.Zero.UserPositions.Dtos
* 类 名  称 :     UserPositionEditDto
* 版      本 :      v1.0.0.0
* 文 件  名 :     UserPositionEditDto.cs
* 描      述 :     职位信息管理编辑Dto
* 创建时间 :     2018/5/16 9:57:51
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
    /// 职位信息管理编辑Dto
    /// </summary>
    [AutoMap(typeof(UserPosition))]
    public class UserPositionEditDto
    {
	    /// <summary>
        ///   主键Id
        /// </summary>
        [DisplayName("主键Id")]
		public long? Id{get;set;}
        /// <summary>
        /// 职位名称
        /// </summary>
		[DisplayName("职位名称")]
        [Required]
        [MaxLength(20)]
        public string PositionName { get; set; }

        /// <summary>
        /// 职位等级
        /// </summary>
		[DisplayName("职位等级")]
        [Required]
        [Range(1, 100)]
        public int RankOfPosition { get; set; }

    }
}
