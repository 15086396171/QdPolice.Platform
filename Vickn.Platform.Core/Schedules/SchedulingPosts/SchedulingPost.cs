using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vickn.Platform.Schedules.SchedulingPosts
{
   public class SchedulingPost : FullAuditedEntity<long>
    {
        /// <summary>
        /// 岗位名称
        /// </summary>
        public string PostName { get; set; }

        
    }
}
