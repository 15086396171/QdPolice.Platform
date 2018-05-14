/*
* 命名空间 :     Vickn.Platform.PbManagement.ChangWorks.Authorization
* 类 名  称 :     ChangeWorkAppPermissions
* 版      本 :      v1.0.0.0
* 文 件  名 :     ChangeWorkAppPermissions.cs
* 描      述 :      定义系统的权限名称的字符串常量
* 创建时间 :     2018/5/14 9:16:02
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

namespace Vickn.Platform.PbManagement.ChangeWorks.Authorization
{
	/// <summary>
	/// 定义系统的权限名称的字符串常量。
    /// <see cref="ChangeWorkAppAuthorizationProvider"/>中对权限的定义.
    /// </summary>
   public static class ChangeWorkAppPermissions
    {
        /// <summary>
        /// 换班管理权限
        /// </summary>
        public const string ChangeWork = "Pages.ChangeWork";

		/// <summary>
        /// 换班管理创建权限
        /// </summary>
        public const string ChangeWork_CreateChangeWork = "Pages.ChangeWork.CreateChangeWork";

		/// <summary>
        /// 换班管理修改权限
        /// </summary>
        public const string ChangeWork_EditChangeWork = "Pages.ChangeWork.EditChangeWork";

		/// <summary>
        /// 换班管理删除权限
        /// </summary>
        public const string ChangeWork_DeleteChangeWork = "Pages.ChangeWork.DeleteChangeWork";
    }
}