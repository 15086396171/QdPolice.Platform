/*
* 命名空间 :     Vickn.Platform.HandheldTerminals.Authorization
* 类 名  称 :     ForensicsRecordAppPermissions
* 版      本 :      v1.0.0.0
* 文 件  名 :     ForensicsRecordAppPermissions.cs
* 描      述 :      定义系统的权限名称的字符串常量
* 创建时间 :     2018/2/5 17:40:05
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

namespace Vickn.Platform.HandheldTerminals.Authorization
{
	/// <summary>
	/// 定义系统的权限名称的字符串常量。
    /// <see cref="ForensicsRecordAppAuthorizationProvider"/>中对权限的定义.
    /// </summary>
   public static class ForensicsRecordAppPermissions
    {
        /// <summary>
        /// 取证记录管理权限
        /// </summary>
        public const string ForensicsRecord = "Pages.ForensicsRecord";

		/// <summary>
        /// 取证记录管理创建权限
        /// </summary>
        public const string ForensicsRecord_CreateForensicsRecord = "Pages.ForensicsRecord.CreateForensicsRecord";

		/// <summary>
        /// 取证记录管理修改权限
        /// </summary>
        public const string ForensicsRecord_EditForensicsRecord = "Pages.ForensicsRecord.EditForensicsRecord";

		/// <summary>
        /// 取证记录管理删除权限
        /// </summary>
        public const string ForensicsRecord_DeleteForensicsRecord = "Pages.ForensicsRecord.DeleteForensicsRecord";
    }
}