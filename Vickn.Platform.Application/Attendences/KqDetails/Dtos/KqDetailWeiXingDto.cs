using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vickn.Platform.Attendences.KqDetails.Dtos
{
    public class KqDetailWeiXingDto
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 是否为NFC打卡
        /// </summary>
        public int isNFC { get; set; }
        /// <summary>
        /// 打卡地理位置
        /// </summary>
        public string Position { get; set; }
        /// <summary>
        /// 外出事由
        /// </summary>
        public string OutGoingCause { get; set; }
    }
}
