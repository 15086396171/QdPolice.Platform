using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vickn.Platform.Attendances.KqShifts;

namespace Vickn.Platform.Attendences.KqShifts.Dtos
{
    /// <summary>
    /// 考勤班次管理编辑Dto
    /// </summary>
      [AutoMap(typeof(KqShift))]
    public class KqShiftEditDto: EntityDto<long>
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
        /// <summary>
        /// 考勤班次对应用户
        /// </summary>
        public KqShiftUser KqShiftUser { get; set; }
        
    }
}
