/*
* 命名空间 :     Vickn.Platform.PbManagement.ChangWorks.Dtos
* 类 名  称 :     GetChangeWorkInput
* 版      本 :      v1.0.0.0
* 文 件  名 :     GetChangeWorkInput.cs
* 描      述 :     换班管理Dto
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
    /// 换班管理Dto
    /// </summary>
    [AutoMap(typeof(ChangeWork))]
    public class ChangeWorkDto : EntityDto<long>
    {
        public int PositionPbMapId { get; set; }

        public int BePositionPbMapId { get; set; }

        public int UserId { get; set; }

        public string UserName { get; set; }

        public int BeUserId { get; set; }

        public string BeUserName { get; set; }

        public string Reason { get; set; }

        public string TimeStr { get; set; }

        public string BeTimeStr { get; set; }

        public string PositionName { get; set; }

        public string BePositionName { get; set; }


       
        [DisplayName("换班进行状态")]
        public string Status { get; set; }


        public string StatusDes { get; set; }

        public int LeaderId { get; set; }

        public string Leader { get; set; }

        public bool IsOnDuty { get; set; }

    }
}
