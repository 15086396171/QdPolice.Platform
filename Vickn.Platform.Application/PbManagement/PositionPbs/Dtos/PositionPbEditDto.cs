/*
* 命名空间 :     Vickn.Platform.PbManagement.PositionPbs.Dtos
* 类 名  称 :     PositionPbEditDto
* 版      本 :      v1.0.0.0
* 文 件  名 :     PositionPbEditDto.cs
* 描      述 :     单个岗位下排班时间管理编辑Dto
* 创建时间 :     2018/5/7 13:34:38
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities;
using Vickn.Platform.PbManagement.PositionPbTimes.Dtos;

namespace Vickn.Platform.PbManagement.PositionPbs.Dtos
{
    /// <summary>
    /// 单个岗位下排班时间管理编辑Dto
    /// </summary>
    [AutoMap(typeof(PositionPb))]
    public class PositionPbEditDto:Entity
    {

        /// <summary>
        /// 单个岗位排班标题Id
        /// </summary>
		[DisplayName("单个岗位排班标题Id")]
        public int PbPositionId { get; set; }

        /// <summary>
        /// 值班日期
        /// </summary>
		[DisplayName("值班日期")]
        public DateTime DutyDate { get; set; }

        /// <summary>
        /// 岗位Id
        /// </summary>
        public int PositionId { get; set; }

        public ICollection<ImportPositionPbTimeDto> PositionPbTimes { get; set; }

    }
}
