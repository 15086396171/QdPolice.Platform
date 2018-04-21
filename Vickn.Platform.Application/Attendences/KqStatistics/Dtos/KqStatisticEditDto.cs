using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vickn.Platform.Attendences.KqStatistics.Dtos
{
   public class KqStatisticEditDto
    {
        public string UserName { get; set; }
        public string GroupName { get; set; }

        public int NormalDay { get; set; }

        public int LateDay { get; set; }

        public int LeaveEarlyDay { get; set; }

        public int AbsenteeismDay { get; set; }
    }
}
