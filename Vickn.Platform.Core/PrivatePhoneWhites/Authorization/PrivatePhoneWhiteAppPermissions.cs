/*
* 命名空间 :     Vickn.Platform.PrivatePhoneWhites.Authorization
* 类 名  称 :     PrivatePhoneWhiteAppPermissions
* 版      本 :      v1.0.0.0
* 文 件  名 :     PrivatePhoneWhiteAppPermissions.cs
* 描      述 :      定义系统的权限名称的字符串常量
* 创建时间 :     2018/2/23 14:15:09
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

namespace Vickn.Platform.PrivatePhoneWhites.Authorization
{
	/// <summary>
	/// 定义系统的权限名称的字符串常量。
    /// <see cref="PrivatePhoneWhiteAppAuthorizationProvider"/>中对权限的定义.
    /// </summary>
   public static class PrivatePhoneWhiteAppPermissions
    {
        /// <summary>
        /// 个人白名单管理权限
        /// </summary>
        public const string PrivatePhoneWhite = "Pages.PrivatePhoneWhite";

		/// <summary>
        /// 个人白名单管理创建权限
        /// </summary>
        public const string PrivatePhoneWhite_CreatePrivatePhoneWhite = "Pages.PrivatePhoneWhite.CreatePrivatePhoneWhite";

		/// <summary>
        /// 个人白名单管理修改权限
        /// </summary>
        public const string PrivatePhoneWhite_EditPrivatePhoneWhite = "Pages.PrivatePhoneWhite.EditPrivatePhoneWhite";

		/// <summary>
        /// 个人白名单管理删除权限
        /// </summary>
        public const string PrivatePhoneWhite_DeletePrivatePhoneWhite = "Pages.PrivatePhoneWhite.DeletePrivatePhoneWhite";
    }
}