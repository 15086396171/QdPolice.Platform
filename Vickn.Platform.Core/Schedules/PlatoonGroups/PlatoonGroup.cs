using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vickn.Platform.Schedules.PlatoonGroups
{
   public class PlatoonGroup : FullAuditedEntity<long>
    {
        /// <summary>
        /// 排班组名称
        /// </summary>
        public string PlatoonGroupName { get; set; }

        /// <summary>
        /// 组长名称
        /// </summary>
        public string GroupLeaderName { get; set; }

        /// <summary>
        /// 组员list
        /// </summary>
        public virtual GroupMember GroupMembers { get; set; }
    }
}
