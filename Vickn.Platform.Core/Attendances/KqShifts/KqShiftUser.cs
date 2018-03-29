using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Vickn.Platform.Attendances.KqShifts
{
   public class KqShiftUser: FullAuditedEntity<long>
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
