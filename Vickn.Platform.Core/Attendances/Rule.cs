using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vickn.Platform.Zero;

namespace Vickn.Platform.Attendances
{
    /// <summary>
    /// 考勤规则
    /// </summary>
    public class Rule:AtUserTime
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public int Id { get; set; }

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
