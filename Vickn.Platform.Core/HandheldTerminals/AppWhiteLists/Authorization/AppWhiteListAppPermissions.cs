/*
* 命名空间 :     Vickn.Platform.HandheldTerminals.AppWhiteLists.Authorization
* 类 名  称 :     AppWhiteListAppPermissions
* 版      本 :      v1.0.0.0
* 文 件  名 :     AppWhiteListAppPermissions.cs
* 描      述 :      定义系统的权限名称的字符串常量
* 创建时间 :     2018/2/5 15:11:33
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

namespace Vickn.Platform.HandheldTerminals.AppWhiteLists.Authorization
{
	/// <summary>
	/// 定义系统的权限名称的字符串常量。
    /// <see cref="AppWhiteListAppAuthorizationProvider"/>中对权限的定义.
    /// </summary>
   public static class AppWhiteListAppPermissions
    {
        /// <summary>
        /// 应用白名单管理权限
        /// </summary>
        public const string AppWhiteList = "Pages.AppWhiteList";

		/// <summary>
        /// 应用白名单管理创建权限
        /// </summary>
        public const string AppWhiteList_CreateAppWhiteList = "Pages.AppWhiteList.CreateAppWhiteList";

		/// <summary>
        /// 应用白名单管理修改权限
        /// </summary>
        public const string AppWhiteList_EditAppWhiteList = "Pages.AppWhiteList.EditAppWhiteList";

		/// <summary>
        /// 应用白名单管理删除权限
        /// </summary>
        public const string AppWhiteList_DeleteAppWhiteList = "Pages.AppWhiteList.DeleteAppWhiteList";
    }
}