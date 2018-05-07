/*
* 命名空间 :     Vickn.Platform.PbManagement.PositionPbs.Authorization
* 类 名  称 :     PositionPbAppPermissions
* 版      本 :      v1.0.0.0
* 文 件  名 :     PositionPbAppPermissions.cs
* 描      述 :      定义系统的权限名称的字符串常量
* 创建时间 :     2018/5/7 13:34:37
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

namespace Vickn.Platform.PbManagement.PositionPbs.Authorization
{
	/// <summary>
	/// 定义系统的权限名称的字符串常量。
    /// <see cref="PositionPbAppAuthorizationProvider"/>中对权限的定义.
    /// </summary>
   public static class PositionPbAppPermissions
    {
        /// <summary>
        /// 单个岗位下排班时间管理权限
        /// </summary>
        public const string PositionPb = "Pages.PositionPb";

		/// <summary>
        /// 单个岗位下排班时间管理创建权限
        /// </summary>
        public const string PositionPb_CreatePositionPb = "Pages.PositionPb.CreatePositionPb";

		/// <summary>
        /// 单个岗位下排班时间管理修改权限
        /// </summary>
        public const string PositionPb_EditPositionPb = "Pages.PositionPb.EditPositionPb";

		/// <summary>
        /// 单个岗位下排班时间管理删除权限
        /// </summary>
        public const string PositionPb_DeletePositionPb = "Pages.PositionPb.DeletePositionPb";
    }
}