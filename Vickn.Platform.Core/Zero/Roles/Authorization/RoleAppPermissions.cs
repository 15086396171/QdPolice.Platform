/*
* 命名空间 :     Vickn.Platform.Authorization.Roles.Authorization
* 类 名  称 :     RoleAppPermissions
* 版      本 :      v1.0.0.0
* 文 件  名 :     RoleAppPermissions.cs
* 描      述 :      定义系统的权限名称的字符串常量
* 创建时间 :     2017/2/20 15:46:59
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

namespace Vickn.Platform.Authorization.Roles.Authorization
{
	/// <summary>
	/// 定义系统的权限名称的字符串常量。
    /// <see cref="RoleAppAuthorizationProvider"/>中对权限的定义.
    /// </summary>
   public static class RoleAppPermissions
    {
        /// <summary>
        /// 角色管理权限
        /// </summary>
        public const string Role = "Pages.Role";

		/// <summary>
        /// 角色管理创建权限
        /// </summary>
        public const string Role_CreateRole = "Pages.Role.CreateRole";

		/// <summary>
        /// 角色管理修改权限
        /// </summary>
        public const string Role_EditRole = "Pages.Role.EditRole";

		/// <summary>
        /// 角色管理删除权限
        /// </summary>
        public const string Role_DeleteRole = "Pages.Role.DeleteRole";

        public const string Role_EditRolePermission = "Pages.Role.EditRolePermission";
    }
}