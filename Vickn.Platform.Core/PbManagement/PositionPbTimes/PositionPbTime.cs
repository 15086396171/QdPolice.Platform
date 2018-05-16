// ===============================================================================
// 命名空间 :     NanNingSSOMS.DAL.Model.PbManagementV3
// 类 名  称 :     PositionPbTimeV3
// 版      本 :      v1.0.0.0
// 文 件  名 :     PositionPbTimeV3.cs
// 描      述 :      
// 作      者 :      dark_yx-i
// 创建时间 :     2016-07-18 17:35:36
// 修 改  人 :     dark_yx-i
// 修改时间 :     2016-07-18 17:35:36
// ===============================================================================
// Copyright © DARK_YX-I-PC 2016 . All rights reserved.
// ===============================================================================

using System;
using System.Collections.Generic;
using Abp.Domain.Entities;
using Vickn.Platform.PbManagement.PositionPbMaps;

namespace Vickn.Platform.PbManagement.PositionPbTimes
{
    /// <summary>
    /// 当天上下班时间
    /// </summary>
    public class PositionPbTime : Entity<long>
    {
        /// <summary>
        /// 是否已值班
        /// </summary>
        public bool IsDuty { get; set; }

        public long PositionPbId { get; set; }

        /// <summary>
        /// 上班时间
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// 下班时间
        /// </summary>
        public DateTime EndTime { get; set; }

        public long UserId { get; set; }

        public string RealName { get; set; }

        /// <summary>
        /// 人员安排
        /// </summary>
        public ICollection<PositionPbMap> PositionPbMaps { get; set; }
    }
}
