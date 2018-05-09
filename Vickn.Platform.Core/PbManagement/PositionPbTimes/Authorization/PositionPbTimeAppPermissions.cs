/*
* 命名空间 :     Vickn.Platform.PbManagement.PositionPbTimes.Authorization
* 类 名  称 :     PositionPbTimeAppPermissions
* 版      本 :      v1.0.0.0
* 文 件  名 :     PositionPbTimeAppPermissions.cs
* 描      述 :      定义系统的权限名称的字符串常量
* 创建时间 :     2018/5/8 14:06:14
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

namespace Vickn.Platform.PbManagement.PositionPbTimes.Authorization
{
	/// <summary>
	/// 定义系统的权限名称的字符串常量。
    /// <see cref="PositionPbTimeAppAuthorizationProvider"/>中对权限的定义.
    /// </summary>
   public static class PositionPbTimeAppPermissions
    {
        /// <summary>
        /// 当天上下班时间管理权限
        /// </summary>
        public const string PositionPbTime = "Pages.PositionPbTime";

		/// <summary>
        /// 当天上下班时间管理创建权限
        /// </summary>
        public const string PositionPbTime_CreatePositionPbTime = "Pages.PositionPbTime.CreatePositionPbTime";

		/// <summary>
        /// 当天上下班时间管理修改权限
        /// </summary>
        public const string PositionPbTime_EditPositionPbTime = "Pages.PositionPbTime.EditPositionPbTime";

		/// <summary>
        /// 当天上下班时间管理删除权限
        /// </summary>
        public const string PositionPbTime_DeletePositionPbTime = "Pages.PositionPbTime.DeletePositionPbTime";
    }
}