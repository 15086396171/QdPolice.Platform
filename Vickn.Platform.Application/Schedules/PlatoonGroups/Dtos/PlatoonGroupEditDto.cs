/*
* 命名空间 :     Vickn.Platform.Schedules.PlatoonGroups.Dtos
* 类 名  称 :     PlatoonGroupEditDto
* 版      本 :      v1.0.0.0
* 文 件  名 :     PlatoonGroupEditDto.cs
* 描      述 :     排班组管理编辑Dto
* 创建时间 :     2018/5/3 17:22:53
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace Vickn.Platform.Schedules.PlatoonGroups.Dtos
{
    /// <summary>
    /// 排班组管理编辑Dto
    /// </summary>
    [AutoMap(typeof(PlatoonGroup))]
    public class PlatoonGroupEditDto
    {
	    /// <summary>
        ///   主键Id
        /// </summary>
        [DisplayName("主键Id")]
		public long? Id{get;set;}
        /// <summary>
        /// 排班组名称
        /// </summary>
		[DisplayName("排班组名称")]
        [MaxLength(100)]
        public string PlatoonGroupName { get; set; }

        /// <summary>
        /// 组长名称
        /// </summary>
		[DisplayName("组长名称")]
        [MaxLength(100)]
        public string GroupLeaderName { get; set; }

    }
}
