/*
* 命名空间 :     Vickn.Platform.PbManagement.Positions.Authorization
* 类 名  称 :     PositionAppPermissions
* 版      本 :      v1.0.0.0
* 文 件  名 :     PositionAppPermissions.cs
* 描      述 :      定义系统的权限名称的字符串常量
* 创建时间 :     2018/5/6 14:16:39
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

namespace Vickn.Platform.PbManagement.Positions.Authorization
{
	/// <summary>
	/// 定义系统的权限名称的字符串常量。
    /// <see cref="PositionAppAuthorizationProvider"/>中对权限的定义.
    /// </summary>
   public static class PositionAppPermissions
    {
        /// <summary>
        /// 岗位管理权限
        /// </summary>
        public const string Position = "Pages.Position";

		/// <summary>
        /// 岗位管理创建权限
        /// </summary>
        public const string Position_CreatePosition = "Pages.Position.CreatePosition";

		/// <summary>
        /// 岗位管理修改权限
        /// </summary>
        public const string Position_EditPosition = "Pages.Position.EditPosition";

		/// <summary>
        /// 岗位管理删除权限
        /// </summary>
        public const string Position_DeletePosition = "Pages.Position.DeletePosition";
    }
}