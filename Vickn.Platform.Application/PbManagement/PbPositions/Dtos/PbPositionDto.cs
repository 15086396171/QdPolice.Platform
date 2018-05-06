/*
* 命名空间 :     Vickn.Platform.PbManagement.PbPositions.Dtos
* 类 名  称 :     GetPbPositionInput
* 版      本 :      v1.0.0.0
* 文 件  名 :     GetPbPositionInput.cs
* 描      述 :     排班岗位管理Dto
* 创建时间 :     2018/5/6 15:05:50
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Vickn.Platform.PbManagement.Positions.Dtos;

namespace Vickn.Platform.PbManagement.PbPositions.Dtos
{
    /// <summary>
    /// 排班岗位管理Dto
    /// </summary>
    [AutoMap(typeof(PbPosition))]
    public class PbPositionDto : EntityDto<int>
    {
        /// <summary>
        /// 是否已排班
        /// </summary>
		[DisplayName("是否已排班")]
        public bool IsTrue { get; set; }

        /// <summary>
        /// 月份
        /// </summary>
		[DisplayName("月份")]
        public DateTime Month { get; set; }

        /// <summary>
        /// 岗位 
        /// </summary>
        public PositionDto Position { get; set; }

    }
}
