using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vickn.Platform.Attendances.Leaves
{
   public class Leave:Entity
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// 用户姓名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 请假类别（病假：0/事假：1）
        /// </summary>
        public string LeaveType { get; set; }

        /// <summary>
        /// 假期开始时间
        /// </summary>
        public string HolidayStartTime { get; set; }

        /// <summary>
        /// 假期结束时间
        /// </summary>
        public string HolidayEndTime { get; set; }

        /// <summary>
        /// 请假天数
        /// </summary>
        public int LeaveDays { get; set; }

        /// <summary>
        /// 请假原因
        /// </summary>
        public string LevaeReason { get; set; }

        /// <summary>
        /// 审批状态
        /// </summary>
        public string StateOfApproval { get; set; }

        /// <summary>
        /// 审批时间
        /// </summary>
        public DateTime TimeOfApproval { get; set; }

        /// <summary>
        /// 审批人
        /// </summary>
        public string UserOfApproval { get; set; }
    }
}
