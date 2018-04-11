using System;
using System.Collections.Generic;
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
    public class KqMachineDto : EntityDto<long>
    {
        /// <summary>
        /// 考勤机编号
        /// </summary>
        public int KQMachineNo { get; set; }
        /// <summary>
        /// 考勤机地理位置
        /// </summary>
        public string KQMachinePosition { get; set; }
    }
}
