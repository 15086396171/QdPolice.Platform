using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vickn.Platform.Attendances.KqShifts;

namespace Vickn.Platform.Attendences.KqShifts.Dtos
{
    /// <summary>
    /// 考勤班次对应用户管理编辑Dto
    /// </summary>
    [AutoMap(typeof(KqShiftUser))]
    public class KqShiftUserEidtDto:Entity
    {
        /// <summary>
        /// 班次名称
        /// </summary>
        public string ShiftName { get; set; }

        /// <summary>
        /// 班次对应的用户名称
        /// </summary>
        public string UserName { get; set; }

    }
}
