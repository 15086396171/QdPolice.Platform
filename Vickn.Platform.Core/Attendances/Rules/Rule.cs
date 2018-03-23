using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vickn.Platform.Attendances.Rules
{
    /// <summary>
    /// 考勤规则
    /// </summary>
   public class Rule: FullAuditedEntity<long>
    {
        /// <summary>
        /// 上班时间
        /// </summary>
        public string WorkTime { get; set; }

        /// <summary>
        /// 下班时间
        /// </summary>
        public string ClosingTime { get; set; }

    }
}
