using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vickn.Platform.PbManagement.PositionPbTimes.Dtos
{
   public class PositionPbTimeListDto
    {
        /// <summary>
        /// 排班时间段
        /// </summary>
        [Description("上班时间")]
        public string PbTime { get; set; }
     
    }
}
