﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Organizations;
using Vickn.Platform.PbManagement.PositionPbs;


namespace Vickn.Platform.PbManagement.PbPositions
{
    /// <summary>
    /// 排班岗位表*标识当前月份下单个岗位的排班标题
    /// 作者：dark_yx
    /// 创建时间：2016/5/24
    /// </summary>
    public class PbPosition : FullAuditedEntity<long>
    {
        /// <summary>
        /// 值班标题
        /// </summary>
        public int PbTitleId { get; set; }

        /// <summary>
        /// 岗位ID
        /// </summary>
        public long OrganizationUnitId { get; set; }

     

        /// <summary>
        /// 岗位ID
        /// </summary>
        public string OrganizationUnitName { get; set; }

        /// <summary>
        /// 是否已排班
        /// </summary>
        [DisplayName("是否已排班")]
        public bool IsTrue { get; set; }

        /// <summary>
        /// 月份
        /// </summary>
        [DisplayName("月份")]
        public DateTime Month { get; set; }

        public virtual ICollection<PositionPb> PositionPbs { get; set; }
    }
}
