/*
* 命名空间 :     Vickn.Platform.PbManagement.PbPositions.Dtos
* 类 名  称 :     PbPositionEditDto
* 版      本 :      v1.0.0.0
* 文 件  名 :     PbPositionEditDto.cs
* 描      述 :     排班岗位管理编辑Dto
* 创建时间 :     2018/5/6 15:05:49
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace Vickn.Platform.PbManagement.PbPositions.Dtos
{
    /// <summary>
    /// 排班岗位管理编辑Dto
    /// </summary>
    [AutoMap(typeof(PbPosition))]
    public class PbPositionEditDto
    {
	    /// <summary>
        ///   主键Id
        /// </summary>
        [DisplayName("主键Id")]
		public int? Id{get;set;}
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

    }
}
