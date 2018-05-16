using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vickn.Platform.Zero.UserPositions
{

    /// <summary>
    /// 职位信息
    /// </summary>
    public class UserPosition : FullAuditedEntity<long>
    {
        /// <summary>
        /// 职位名称
        /// </summary>
        public string PositionName { get; set; }

        /// <summary>
        /// 职位等级
        /// </summary>
        public int RankOfPosition { get; set; }
    }
}
