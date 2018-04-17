using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.AutoMapper;
using Vickn.Platform.Attendances.KQDetails;

namespace Vickn.Platform.Attendences.KqDetails.Dtos
{
    /// <summary>
    /// 考勤流水Dto
    /// </summary>
    [AutoMap(typeof(KqAllDetail))]
   public class KqDetailEditDto
    {
        /// <summary>
        ///   主键Id
        /// </summary>
        [DisplayName("主键Id")]
        public long? Id { get; set; }

        /// <summary>
        /// 用户姓名
        /// </summary>
        [DisplayName("姓名")]
        public string UserName { get; set; }

        /// <summary>
        /// 签到时间
        /// </summary>
        [DisplayName("签到时间")]
        public DateTime QDTime { get; set; }


        /// <summary>
        /// 签到方式是否为NFC（NFC或微信扫码）
        /// </summary>
        [DisplayName("签到方式")]
        public int IsNFC { get; set; }

        /// <summary>
        /// 签到地理位置
        /// </summary>
        [DisplayName("地理位置")]
        public string QDPostion { get; set; }
    }
}
