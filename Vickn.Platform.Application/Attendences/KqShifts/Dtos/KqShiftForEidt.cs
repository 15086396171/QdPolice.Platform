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
    /// 用于获取添加或编辑 考勤班次管理时使用的Dto
    /// </summary>
    public class KqShiftForEidt 
    {
        ///考勤班次实体
       public KqShiftEditDto KqShiftEditDto { get; set; }
    }
}
