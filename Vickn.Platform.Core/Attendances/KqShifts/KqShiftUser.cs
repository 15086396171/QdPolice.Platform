using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vickn.Platform.Users;

namespace Vickn.Platform.Attendances.KqShifts
{
   public class KqShiftUser:Entity<long>
    
    {
        public long UserId { get; set; }

        public virtual User User { get; set; }

        public long KqShiftId { get; set; }

       
    }
}
