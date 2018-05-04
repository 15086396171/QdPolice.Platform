/*
* 命名空间 :     Vickn.Platform.Schedules.PlatoonGroups.Dtos
* 类 名  称 :     GetPlatoonGroupInput
* 版      本 :      v1.0.0.0
* 文 件  名 :     GetPlatoonGroupInput.cs
* 描      述 :     排班组管理Dto
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
    /// 排班组管理Dto
    /// </summary>
    [AutoMap(typeof(PlatoonGroup))]
    public class PlatoonGroupDto : EntityDto<long>
    {
        /// <summary>
        /// 排班组名称
        /// </summary>
		[DisplayName("排班组名称")]
        public string PlatoonGroupName { get; set; }

        /// <summary>
        /// 组长名称
        /// </summary>
		[DisplayName("组长名称")]
        public string GroupLeaderName { get; set; }

    }
}
