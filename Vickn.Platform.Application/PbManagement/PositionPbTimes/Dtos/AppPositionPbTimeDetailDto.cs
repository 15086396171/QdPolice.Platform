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

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 岗位
        /// </summary>
        public string positionPbName { get; set; }

    }
}
