/*
* 命名空间 :     Vickn.Platform.Schedules.SchedulingPosts.Dtos
* 类 名  称 :     SchedulingPostEditDto
* 版      本 :      v1.0.0.0
* 文 件  名 :     SchedulingPostEditDto.cs
* 描      述 :     岗位设置管理编辑Dto
* 创建时间 :     2018/5/3 15:40:49
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace Vickn.Platform.Schedules.SchedulingPosts.Dtos
{
    /// <summary>
    /// 岗位设置管理编辑Dto
    /// </summary>
    [AutoMap(typeof(SchedulingPost))]
    public class SchedulingPostEditDto
    {
	    /// <summary>
        ///   主键Id
        /// </summary>
        [DisplayName("主键Id")]
		public long? Id{get;set;}
        /// <summary>
        /// 岗位名称
        /// </summary>
		[DisplayName("岗位名称")]
        [Required]
        public string PostName { get; set; }

    }
}
