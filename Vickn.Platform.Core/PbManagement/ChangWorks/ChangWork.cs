using Abp.Domain.Entities;
using NanNingSSOMS.DAL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vickn.Platform.PbManagement.ChangWorks
{
    public class ChangWorkV3 : Entity
    {
        [Required, DisplayName("值班时间")]
        public int PositionPbMapV3Id { get; set; }

        [Required, DisplayName("换班时间")]
        public int BePositionPbMapV3Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        [DisplayName("换班人")]
        public string UserName { get; set; }

        [Required]
        public int BeUserId { get; set; }

        [DisplayName("被换班人"), Required]
        public string BeUserName { get; set; }

        [DisplayName("换班原因"), Required]
        public string Reason { get; set; }

        [Required]
        [DisplayName("换班前时间")]
        public string TimeStr { get; set; }

        [Required]
        [DisplayName("换班后时间")]
        public string BeTimeStr { get; set; }

        [DisplayName("换班前岗位")]
        [Required]
        public string PositionName { get; set; }

        [Required]
        [DisplayName("换班后岗位")]
        public string BePositionName { get; set; }

        [Required]
        public ChangeWorkStatus Status { get; set; }

        [DisplayName("状态")]
        [Required]
        public string StatusDes { get; set; }

        [DisplayName("审批领导")]
        public int LeaderId { get; set; }

        [DisplayName("审批领导")]
        public string Leader { get; set; }
        public bool IsOnDuty { get; set; }
    }

    public class ChangeWorkUserTime
    {

        public string UserName { get; set; }

        public int UserId { get; set; }

        public int PositionPbMapV3Id { get; set; }

        public int PositionPbV3Id { get; set; }

        public int PositionV3Id { get; set; }

        public string PositionV3Name { get; set; }

        public DateTime Time { get; set; }

        /// <summary>
        ///  值班开始时间
        /// </summary>
        public DateTime DutyStartTime { get; set; }

        /// <summary>
        /// 值班结束时间
        /// </summary>
        public DateTime DutyEndTime { get; set; }

    }
}
