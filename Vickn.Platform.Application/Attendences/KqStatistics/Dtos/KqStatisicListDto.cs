using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vickn.Platform.Attendences.KqStatistics.Dtos
{
    /// <summary>
    /// 考勤统计Dto
    /// </summary>
   public class KqStatisicListDto
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 考勤班次名称
        /// </summary>
        public string KqShiftName { get; set; }
        /// <summary>
        /// 正常天数
        /// </summary>
        public int NormalDay { get; set; }
        /// <summary>
        /// 迟到天数
        /// </summary>
        public int LateDay { get; set; }
        /// <summary>
        /// 早退
        /// </summary>
        public int LeaveEarlyDay { get; set; }
        /// <summary>
        /// 缺勤
        /// </summary>
        public int AbsenteeismDay { get; set; }

        /// <summary>
        /// 异常
        /// </summary>
        public int AbnormalDay { get; set; }
    }
}
