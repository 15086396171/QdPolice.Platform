using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Vickn.Platform.Attendances.KqMachines;

namespace Vickn.Platform.Attendences.KqMachines.Dtos
{
    /// <summary>
    /// 考勤机查询参数Dto
    /// </summary>
    [AutoMap(typeof(KqMachine))]
    public class KqMachineDto 
    {

        /// <summary>
        ///   主键Id
        /// </summary>
        [DisplayName("主键Id")]
        public long? Id { get; set; }
        /// <summary>
        /// 考勤机编号
        /// </summary>
        [DisplayName("考勤机编号")]
        public int KQMachineNo { get; set; }

        /// <summary>
        /// 考勤机地理位置
        /// </summary>
        [Required]
        [DisplayName("考勤机地理位置")]
        public string KQMachinePosition { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [DisplayName("备注")]
        public string Remark { get; set; }
    }
}
