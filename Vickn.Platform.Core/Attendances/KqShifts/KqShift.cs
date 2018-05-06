using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vickn.Platform.Attendances.KqShifts
{
   public class KqShift: FullAuditedEntity<long>
    {
        /// <summary>
        /// 班次名称
        /// </summary>
        public string ShiftName { get; set; }
        /// <summary>
        /// 上班时间
        /// </summary>
        public string WorkTime { get; set; }
        /// <summary>
        /// 下班时间
        /// </summary>
        public string ClosingTime { get; set; }
        /// <summary>
        /// 考勤班次对应的用户列表
        /// </summary>
       
        public virtual List<KqShiftUser> KqShiftUsers { get; set; }
    }
}
