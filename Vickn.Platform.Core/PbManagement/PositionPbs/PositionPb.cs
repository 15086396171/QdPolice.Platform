// ===============================================================================
// 命名空间 :     NanNingSSOMS.DAL.Model.PbManagementV3
// 类 名  称 :     PositionPbV3
// 版      本 :      v1.0.0.0
// 文 件  名 :     PositionPbV3
// 描      述 :      
// 作      者 :      dark_yx-i
// 创建时间 :     2016-07-16 10:05:50
// 修 改  人 :     dark_yx-i
// 修改时间 :     2016-07-16 10:05:50
// ===============================================================================
// Copyright © DARK_YX-I-PC 2016 . All rights reserved.
// ===============================================================================

using System;
using System.Collections.Generic;
using Abp.Domain.Entities;
using Vickn.Platform.PbManagement.PositionPbTimes;

namespace Vickn.Platform.PbManagement.PositionPbs
{
    /// <summary>
    /// 单个岗位下排班时间
    /// </summary>
    public class PositionPb : Entity
    {

        /// <summary>
        /// 单个岗位排班标题Id
        /// </summary>
        public int PbPositionId { get; set; }

        /// <summary>
        /// 岗位Id
        /// </summary>
        public int PositionId { get; set; }



        /// <summary>
        /// 值班日期
        /// </summary>
        public DateTime DutyDate { get; set; }

        public virtual ICollection<PositionPbTime> PositionPbTimes { get; set; }
    }
}
