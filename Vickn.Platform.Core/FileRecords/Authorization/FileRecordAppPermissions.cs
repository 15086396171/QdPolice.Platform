/*
* 命名空间 :     Vickn.Platform.FileRecords.Authorization
* 类 名  称 :     FileRecordAppPermissions
* 版      本 :      v1.0.0.0
* 文 件  名 :     FileRecordAppPermissions.cs
* 描      述 :      定义系统的权限名称的字符串常量
* 创建时间 :     2017/8/13 22:00:21
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

namespace Vickn.Platform.FileRecords.Authorization
{
	/// <summary>
	/// 定义系统的权限名称的字符串常量。
    /// <see cref="FileRecordAppAuthorizationProvider"/>中对权限的定义.
    /// </summary>
   public static class FileRecordAppPermissions
    {
        /// <summary>
        /// 文件记录管理权限
        /// </summary>
        public const string FileRecord = "Pages.FileRecord";

		/// <summary>
        /// 文件记录管理创建权限
        /// </summary>
        public const string FileRecord_CreateFileRecord = "Pages.FileRecord.CreateFileRecord";

		/// <summary>
        /// 文件记录管理修改权限
        /// </summary>
        public const string FileRecord_EditFileRecord = "Pages.FileRecord.EditFileRecord";

		/// <summary>
        /// 文件记录管理删除权限
        /// </summary>
        public const string FileRecord_DeleteFileRecord = "Pages.FileRecord.DeleteFileRecord";
    }
}