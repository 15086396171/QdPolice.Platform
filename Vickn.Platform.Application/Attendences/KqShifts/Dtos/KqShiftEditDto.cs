using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public class KqShiftEditDto
    {
        /// <summary>
        ///   主键Id
        /// </summary>
        [DisplayName("主键Id")]
        public long? Id { get; set; }

        /// <summary>
        /// 班次名称
        /// </summary>
        public string ShiftName { get; set; }
        /// <summary>
        /// 上班时间
        /// </summary>
        public DateTime WorkTime { get; set; }
        /// <summary>
        /// 下班时间
        /// </summary>
        public DateTime ClosingTime { get; set; }

        /// <summary>
        /// 考勤对应用户
        /// </summary>
        [DisplayName("考勤对应用户")]
        public virtual List<KqShiftUserEidtDto> KqShiftUsers { get; set; }


    }
}
