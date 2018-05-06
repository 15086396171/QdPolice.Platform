/*
* 命名空间 :     Vickn.Platform.PbManagement.PbTitles.Authorization
* 类 名  称 :     PbTitleAppPermissions
* 版      本 :      v1.0.0.0
* 文 件  名 :     PbTitleAppPermissions.cs
* 描      述 :      定义系统的权限名称的字符串常量
* 创建时间 :     2018/5/6 14:40:34
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

namespace Vickn.Platform.PbManagement.PbTitles.Authorization
{
	/// <summary>
	/// 定义系统的权限名称的字符串常量。
    /// <see cref="PbTitleAppAuthorizationProvider"/>中对权限的定义.
    /// </summary>
   public static class PbTitleAppPermissions
    {
        /// <summary>
        /// 排班标题管理权限
        /// </summary>
        public const string PbTitle = "Pages.PbTitle";

		/// <summary>
        /// 排班标题管理创建权限
        /// </summary>
        public const string PbTitle_CreatePbTitle = "Pages.PbTitle.CreatePbTitle";

		/// <summary>
        /// 排班标题管理修改权限
        /// </summary>
        public const string PbTitle_EditPbTitle = "Pages.PbTitle.EditPbTitle";

		/// <summary>
        /// 排班标题管理删除权限
        /// </summary>
        public const string PbTitle_DeletePbTitle = "Pages.PbTitle.DeletePbTitle";
    }
}