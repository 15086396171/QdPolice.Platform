/*
* 命名空间 :     Vickn.Platform.Schedules.PlatoonGroups.Authorization
* 类 名  称 :     PlatoonGroupAppPermissions
* 版      本 :      v1.0.0.0
* 文 件  名 :     PlatoonGroupAppPermissions.cs
* 描      述 :      定义系统的权限名称的字符串常量
* 创建时间 :     2018/5/3 17:22:52
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

namespace Vickn.Platform.Schedules.PlatoonGroups.Authorization
{
	/// <summary>
	/// 定义系统的权限名称的字符串常量。
    /// <see cref="PlatoonGroupAppAuthorizationProvider"/>中对权限的定义.
    /// </summary>
   public static class PlatoonGroupAppPermissions
    {
        /// <summary>
        /// 排班组管理权限
        /// </summary>
        public const string PlatoonGroup = "Pages.PlatoonGroup";

		/// <summary>
        /// 排班组管理创建权限
        /// </summary>
        public const string PlatoonGroup_CreatePlatoonGroup = "Pages.PlatoonGroup.CreatePlatoonGroup";

		/// <summary>
        /// 排班组管理修改权限
        /// </summary>
        public const string PlatoonGroup_EditPlatoonGroup = "Pages.PlatoonGroup.EditPlatoonGroup";

		/// <summary>
        /// 排班组管理删除权限
        /// </summary>
        public const string PlatoonGroup_DeletePlatoonGroup = "Pages.PlatoonGroup.DeletePlatoonGroup";
    }
}