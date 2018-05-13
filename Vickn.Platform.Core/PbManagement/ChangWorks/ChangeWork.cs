using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vickn.Platform.PbManagement.ChangWorks
{
    public class ChangeWork: FullAuditedEntity<long>
    {
    
        [Required, DisplayName("值班时间")]
        public int PositionPbMapV3Id { get; set; }

        [Required, DisplayName("换班时间")]
        public int BePositionPbMapV3Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        [DisplayName("换班人用户名")]
        public string UserName { get; set; }

        [Required]
        public int BeUserId { get; set; }

        [DisplayName("被换班人用户名"), Required]
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
        [DisplayName("换班进行状态")]
        public ChangeWorkStatus Status { get; set; }

        [DisplayName("状态")]
        [Required]
        public string StatusDes { get; set; }

        [DisplayName("审批领导Id")]
        public int LeaderId { get; set; }

        [DisplayName("审批领导")]
        public string Leader { get; set; }
        public bool IsOnDuty { get; set; }
    }
}
