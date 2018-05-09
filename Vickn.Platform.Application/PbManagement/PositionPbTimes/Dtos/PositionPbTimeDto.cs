/*
* 命名空间 :     Vickn.Platform.PbManagement.PositionPbTimes.Dtos
* 类 名  称 :     GetPositionPbTimeInput
* 版      本 :      v1.0.0.0
* 文 件  名 :     GetPositionPbTimeInput.cs
* 描      述 :     当天上下班时间管理Dto
* 创建时间 :     2018/5/6 17:23:52
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace Vickn.Platform.PbManagement.PositionPbTimes.Dtos
{
    /// <summary>
    /// 当天上下班时间管理Dto
    /// </summary>
    [AutoMap(typeof(PositionPbTime))]
    public class PositionPbTimeDto : EntityDto<int>
    {
        /// <summary>
        /// 是否已值班
        /// </summary>
		[DisplayName("是否已值班")]
        public bool IsDuty { get; set; }

        /// <summary>
        /// 排班岗位Id
        /// </summary>
        public int PositionPbId { get; set; }

        /// <summary>
        /// 上班时间
        /// </summary>
		[DisplayName("上班时间")]
        public DateTime StartTime { get; set; }

        /// <summary>
        /// 下班时间
        /// </summary>
		[DisplayName("下班时间")]
        public DateTime EndTime { get; set; }

    }
}
