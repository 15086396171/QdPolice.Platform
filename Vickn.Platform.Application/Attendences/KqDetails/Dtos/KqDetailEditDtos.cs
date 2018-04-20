using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vickn.Platform.Attendences.KqDetails.Dtos
{
   public class KqDetailEditDtos
    {
        /// <summary>
        ///   主键Id
        /// </summary>
        [DisplayName("主键Id")]
        public long? Id { get; set; }

        /// <summary>
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
        public string QDPostion { get; set; }

        /// <summary>
        /// 考勤班次Id
        /// </summary>
        public long? KqShiftId { get; set; }
    }
}
