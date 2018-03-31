using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vickn.Platform.Attendences.KqDetails.Dtos
{
    /// <summary>
    /// 打卡流水记录
    /// </summary>
    public class KqAllDetailDto:Entity
    {
        /// 用户姓名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 签到时间
        /// </summary>
        public DateTime QDTime { get; set; }


        /// <summary>
        /// 签到方式是否为NFC（NFC或微信扫码）
        /// </summary>
        public int IsNFC { get; set; }

        /// <summary>
        /// 签到地理位置
        /// </summary>
        public int QDPostion { get; set; }
    }
}
