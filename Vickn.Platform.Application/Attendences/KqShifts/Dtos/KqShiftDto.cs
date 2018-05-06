using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vickn.Platform.Attendances.KqShifts;

namespace Vickn.Platform.Attendences.KqShifts.Dtos
{
    /// <summary>
    /// 考勤班次Dto
    /// </summary>
    [AutoMap(typeof(KqShift))]
    public  class KqShiftDto: EntityDto<long>
    {
        /// <summary>
        /// 班次名称
        /// </summary>
        public string ShiftName { get; set; }
        /// <summary>
        /// 上班时间
        /// </summary>
        public string WorkTime { get; set; }
        /// <summary>
        /// 下班时间
        /// </summary>
        public string ClosingTime { get; set; }
       
    }
}
