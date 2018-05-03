/*
* 命名空间 :     Vickn.Platform.Schedules.SchedulingPosts.Dtos
* 类 名  称 :     GetSchedulingPostInput
* 版      本 :      v1.0.0.0
* 文 件  名 :     GetSchedulingPostInput.cs
* 描      述 :     岗位设置管理Dto
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
    /// 岗位设置管理Dto
    /// </summary>
    [AutoMap(typeof(SchedulingPost))]
    public class SchedulingPostDto : EntityDto<long>
    {
        /// <summary>
        /// 岗位名称
        /// </summary>
		[DisplayName("岗位名称")]
        public string PostName { get; set; }



    }
}
