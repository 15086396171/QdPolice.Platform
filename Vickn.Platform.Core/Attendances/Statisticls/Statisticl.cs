using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vickn.Platform.Attendances.Statisticls
{
    /// <summary>
    /// 考勤信息统计
    /// </summary>
    public class Statisticl:Entity
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 用户姓名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 工作天数（不包含周六，周日）
        /// </summary>
        public string WorkingDays { get; set; }

        /// <summary>
        /// 正常天数
        /// </summary>
        public string NormalDays { get; set; }

        /// <summary>
        /// 请假天数
        /// </summary>
        public string LevaeDays { get; set; }

        /// <summary>
        /// 迟到天数
        /// </summary>
        public string LateDays { get; set; }

        /// <summary>
        /// 早退天数
        /// </summary>
        public string LeaveEarlyDays { get; set; }

        /// <summary>
        /// 缺勤天数
        /// </summary>
        public string AbsenteeismDays { get; set; }


    }
}
