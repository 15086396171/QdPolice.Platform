// ===============================================================================
// 命名空间 :     NanNingSSOMS.DAL.Model.PbManagementV3
// 类 名  称 :     PositionV3
// 版      本 :      v1.0.0.0
// 文 件  名 :     PositionV3
// 描      述 :      
// 作      者 :      dark_yx-i
// 创建时间 :     2016-07-15 16:47:05
// 修 改  人 :     dark_yx-i
// 修改时间 :     2016-07-15 16:47:05
// ===============================================================================
// Copyright © DARK_YX-I-PC 2016 . All rights reserved.
// ===============================================================================

using Abp.Domain.Entities.Auditing;

namespace Vickn.Platform.PbManagement.Positions
{
    /// <summary>
    /// 岗位表
    /// </summary>
    public class Position : FullAuditedEntity
    {
        /// <summary>
        /// 岗位名称
        /// </summary>
        public string Name { get; set; }
    }
}
