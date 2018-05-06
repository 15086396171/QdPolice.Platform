using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
        [DisplayName("班次名称")]
        [Required]
        public string ShiftName { get; set; }
        /// <summary>
        /// 上班时间
        /// </summary>
        [DisplayName("上班时间")]
        [Required]
        public string WorkTime { get; set; }
        /// <summary>
        /// 下班时间
        /// </summary>
        [DisplayName("下班时间")]
        [Required]
        public string ClosingTime { get; set; }

        /// <summary>
        /// 班次对应用户
        /// </summary>
        [DisplayName("班次对应用户")]

        public virtual List<KqShiftUserEidtDto> KqShiftUsers { get; set; }


    }
}
