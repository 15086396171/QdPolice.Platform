using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vickn.Platform.Schedules.PlatoonGroup
{
   public class PlatoonGroup : FullAuditedEntity<long>
    {
        /// <summary>
        /// 排班组名称
        /// </summary>
        public string PostName { get; set; }
    }
}
