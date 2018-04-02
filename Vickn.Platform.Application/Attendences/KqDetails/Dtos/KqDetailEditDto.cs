using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vickn.Platform.Attendances.KQDetails;

namespace Vickn.Platform.Attendences.KqDetails.Dtos
{
    /// <summary>
    /// 考勤app接口信息
    /// </summary>
    [AutoMap(typeof(KqDetail))]
    public class KqDetailEditDto
    {
        /// <summary>
        /// 签到方式是否为NFC（NFC或微信扫码或门禁）
        /// </summary>
        public int IsNFC { get; set; }

        /// <summary>
        /// 签到地理位置（用户微信扫码打卡）
        /// </summary>
        public string QDPosition { get; set; }
    }
}
