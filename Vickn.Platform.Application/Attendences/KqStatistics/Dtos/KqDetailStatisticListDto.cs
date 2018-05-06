using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vickn.Platform.Attendences.KqStatistics.Dtos
{
   public class KqDetailStatisticListDto
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 签到日期（yyyy-MM-dd）
        /// </summary>
        public string DateYMD { get; set; }
        /// <summary>
        /// 上班时间
        /// </summary>
        public string DateWork { get; set; }
        /// <summary>
        /// 上班外出事由
        /// </summary>
        public string OutgoingCauseWork { get; set; }
        /// <summary>
        /// 上班打卡位置
        /// </summary>
        public string QDPostionWork { get; set; }

        /// <summary>
        /// 下班时间（时:分:秒）
        /// </summary>
        public string DateColsing { get; set; }


        /// <summary>
        /// 下班签到地理位置
        /// </summary>
        public string QDPostionClosing { get; set; }

        /// <summary>
        /// 下班外出事由
        /// </summary>

        public string OutgoingCauseClosing { get; set; }
        /// <summary>
        /// 今日考勤打卡类型
        /// </summary>
        public string QDType { get; set; }
    }
}
