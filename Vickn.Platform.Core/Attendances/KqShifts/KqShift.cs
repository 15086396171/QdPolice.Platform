using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
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
        /// 考勤班次对应用户
        /// </summary>
        public KqShiftUser KqShiftUser { get; set; }
  
    }
}
