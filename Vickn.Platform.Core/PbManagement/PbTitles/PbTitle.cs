using System;
using System.Collections.Generic;
using Abp.Domain.Entities.Auditing;
using Vickn.Platform.PbManagement.PbPositions;

namespace Vickn.Platform.PbManagement.PbTitles
{
    /// <summary>
    /// 排班标题表
    /// </summary>
    public class PbTitle : FullAuditedEntity
    {
        /// <summary>
        /// 排班标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 排班时间
        /// </summary>
        public DateTime Month { get; set; }

        /// <summary>
        /// 是否排班
        /// </summary>
        public bool IsPb { get; set; }

        /// <summary>
        /// 当月下所有岗位标题集合
        /// </summary>
        public virtual ICollection<PbPosition> PbPositions { get; set; }
    }
}
