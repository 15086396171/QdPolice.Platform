using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vickn.Platform.PbManagement.PositionPbMaps.Dtos;

namespace Vickn.Platform.PbManagement.PositionPbTimes.Dtos
{
    /// <summary>
    /// 岗位对应班次时间
    /// </summary>
   public class AppPositionPbTimeDetailDto
    {
        [Description("岗位排班Id")]
        public int PositionPbId { get; set; }

        public bool IsDuty { get; set; }
        /// <summary>
        /// 上班时间
        /// </summary>
        [Description("上班时间")]
        public string StartTime { get; set; }
        /// <summary>
        /// 下班时间
        /// </summary>
        [Description("下班时间")]
        public string EndTime { get; set; }

        public long UserId { get; set; }

        public string RealName { get; set; }

        public ICollection<PositionPbMapDto> PositionPbMaps { get; set; }
    }
}
