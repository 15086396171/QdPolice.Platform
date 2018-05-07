/*
* 命名空间 :     Vickn.Platform.PbManagement.PositionPbMaps.Dtos
* 类 名  称 :     GetPositionPbMapInput
* 版      本 :      v1.0.0.0
* 文 件  名 :     GetPositionPbMapInput.cs
* 描      述 :     排班人员管理Dto
* 创建时间 :     2018/5/7 10:29:08
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
    /// 排班人员管理Dto
    /// </summary>
    [AutoMap(typeof(PositionPbMap))]
    public class PositionPbMapDto : EntityDto<int>
    {
        public long UserId { get; set; }

        [Description("真实姓名"), DisplayName("真实姓名")]
        public string RealName { get; set; }

        /// <summary>
        /// 所属时间段
        /// </summary>
		[DisplayName("所属时间段")]
        public int PositionPbTimeId { get; set; }

    }
}
