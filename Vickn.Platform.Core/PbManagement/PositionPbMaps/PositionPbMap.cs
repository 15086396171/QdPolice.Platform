// ===============================================================================
// 命名空间 :     NanNingSSOMS.DAL.Model.PbManagementV3
// 类 名  称 :     PositionPbMapV3
// 版      本 :      v1.0.0.0
// 文 件  名 :     PositionPbMapV3
// 描      述 :      
// 作      者 :      dark_yx-i
// 创建时间 :     2016-07-16 10:10:36
// 修 改  人 :     dark_yx-i
// 修改时间 :     2016-07-16 10:10:36
// ===============================================================================
// Copyright © DARK_YX-I-PC 2016 . All rights reserved.
// ===============================================================================

using Abp.Domain.Entities;
using Vickn.Platform.Users;

namespace Vickn.Platform.PbManagement.PositionPbMaps
{
    /// <summary>
    /// 排班人员
    /// </summary>
    public class PositionPbMap : Entity<long>
    {
        public long UserId { get; set; }

        public virtual User User { get; set; }

        /// <summary>
        /// 所属时间段
        /// </summary>
        public int PositionPbTimeId { get; set; }

    }
}
