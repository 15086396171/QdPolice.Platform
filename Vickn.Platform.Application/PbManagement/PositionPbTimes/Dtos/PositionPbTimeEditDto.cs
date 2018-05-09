/*
* 命名空间 :     Vickn.Platform.PbManagement.PositionPbTimes.Dtos
* 类 名  称 :     PositionPbTimeEditDto
* 版      本 :      v1.0.0.0
* 文 件  名 :     PositionPbTimeEditDto.cs
* 描      述 :     当天上下班时间管理编辑Dto
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
using Abp.Domain.Entities;

namespace Vickn.Platform.PbManagement.PositionPbTimes.Dtos
{
    /// <summary>
    /// 当天上下班时间管理编辑Dto
    /// </summary>
    [AutoMap(typeof(PositionPbTime))]
    public class PositionPbTimeEditDto:Entity
    {
	    
        /// <summary>
        /// 是否已值班
        /// </summary>
		[DisplayName("是否已值班")]
        public bool IsDuty { get; set; }

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
