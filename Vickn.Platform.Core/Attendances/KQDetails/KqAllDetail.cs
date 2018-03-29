using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vickn.Platform.Attendances.Leaves;

namespace Vickn.Platform.Attendances.KQDetails
{
   public class KqAllDetail:Entity
    {
        /// <summary>
        /// 用户姓名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 签到时间
        /// </summary>
        public DateTime QDTime { get; set; }


        /// <summary>
        /// 签到方式是否为NFC（NFC:0,门禁:1,微信扫码:2）
        /// </summary>
        public int IsNFC { get; set; }

        /// <summary>
        /// 签到地理位置
        /// </summary>
        public string QDPostion { get; set; }
    }
}
