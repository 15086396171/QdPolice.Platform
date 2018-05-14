/*
* 命名空间 :     Vickn.Platform.PbManagement.ChangWorks.Dtos
* 类 名  称 :     ChangeWorkEditDto
* 版      本 :      v1.0.0.0
* 文 件  名 :     ChangeWorkEditDto.cs
* 描      述 :     换班管理编辑Dto
* 创建时间 :     2018/5/14 9:16:04
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace Vickn.Platform.PbManagement.ChangeWorks.Dtos
{
    /// <summary>
    /// 换班管理编辑Dto
    /// </summary>
    [AutoMap(typeof(ChangeWork))]
    public class ChangeWorkEditDto
    {
	    /// <summary>
        ///   主键Id
        /// </summary>
        [DisplayName("主键Id")]
		public long? Id{get;set;}

        /// <summary>
        /// 发起人岗位排班Id
        /// </summary>
        [Required]
        public int PositionPbMapId { get; set; }

        /// <summary>
        /// 被换班人岗位排班Id
        /// </summary>
        [Required]
        public int BePositionPbMapId { get; set; }

        /// <summary>
        /// 发起人Id
        /// </summary>
        [Required]
        public int UserId { get; set; }

        [Required]
        [DisplayName("发起人")]
        public string UserName { get; set; }

        [Required]
        [DisplayName("被换班人Id")]
        public int BeUserId { get; set; }

        [Required]
        [DisplayName("发起人姓名")]
        public string BeUserName { get; set; }

        [Required]
        [DisplayName("换班原因")]
        public string Reason { get; set; }

        [Required]
        [DisplayName("值班时间")]
        public string TimeStr { get; set; }

        [Required]
        [DisplayName("被换班人值班时间")]
        public string BeTimeStr { get; set; }

        [Required]
        [DisplayName("发起人岗位")]
        public string PositionName { get; set; }

        [Required]
        [DisplayName("被换班人岗位")]
        public string BePositionName { get; set; }

        [Required]
        [DisplayName("审批状态")]
        public string StatusDes { get; set; }

        public int LeaderId { get; set; }

        [DisplayName("发起人")]
        public string Leader { get; set; }

        [DisplayName("发起人")]
        public bool IsOnDuty { get; set; }

    }
}
