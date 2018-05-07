/*
* 命名空间 :     Vickn.Platform.PbManagement.PositionPbMaps.Dtos
* 类 名  称 :     PositionPbMapEditDto
* 版      本 :      v1.0.0.0
* 文 件  名 :     PositionPbMapEditDto.cs
* 描      述 :     排班人员管理编辑Dto
* 创建时间 :     2018/5/7 10:29:07
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace Vickn.Platform.PbManagement.PositionPbMaps.Dtos
{
    /// <summary>
    /// 排班人员管理编辑Dto
    /// </summary>
    [AutoMap(typeof(PositionPbMap))]
    public class PositionPbMapEditDto
    {
	    /// <summary>
        ///   主键Id
        /// </summary>
        [DisplayName("主键Id")]
		public int? Id{get;set;}
        public long UserId { get; set; }

        /// <summary>
        /// 所属时间段
        /// </summary>
		[DisplayName("所属时间段")]
        public int PositionPbTimeId { get; set; }

    }
}
