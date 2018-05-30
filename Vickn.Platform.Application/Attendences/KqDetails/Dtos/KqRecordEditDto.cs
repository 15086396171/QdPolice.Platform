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
    /// 考勤记录Dto
    /// </summary>
    [AutoMap(typeof(KqDetail))]
    public class KqRecordEditDto
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
        /// 考勤机编号
        /// </summary>
        public string KQMachineNo { get; set; }

        /// <summary>
        /// 上班签到时间
        /// </summary>
        public DateTime QDWorkTime { get; set; }

        /// <summary>
        /// 下班签到时间
        /// </summary>
        public DateTime? QDClosingTime { get; set; }

        /// <summary>
        /// 签到类型（正常：0，迟到：1，早退：2，缺勤：3，请假：4，异常：5）
        /// </summary>
        public int? QDType { get; set; }

        /// <summary>
        /// 签到方式是否为NFC（NFC或微信扫码）
        /// </summary>
        public int? IsNFC { get; set; }



        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
