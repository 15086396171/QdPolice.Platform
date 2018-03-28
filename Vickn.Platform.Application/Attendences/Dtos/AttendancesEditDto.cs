using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vickn.Platform.Attendances;
using Vickn.Platform.Attendances.KQDetails;

namespace Vickn.Platform.Attendences.Dtos
{
    [AutoMap(typeof(KqDetail))]
    public class AttendancesEditDto
    {
        /// <summary>
        /// 签到方式是否为NFC（NFC或微信扫码或门禁）
        /// </summary>
        public int IsNFC { get; set; }

    }
}
