/*
* 命名空间 :     Vickn.Platform.DataDictionaries.Authorization
* 类 名  称 :     DataDictionaryItemAppPermissions
* 版      本 :      v1.0.0.0
* 文 件  名 :     DataDictionaryItemAppPermissions.cs
* 描      述 :      定义系统的权限名称的字符串常量
* 创建时间 :     2017/6/12 16:57:18
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

namespace Vickn.Platform.DataDictionaries.Authorization
{
	/// <summary>
	/// 定义系统的权限名称的字符串常量。
    /// <see cref="DataDictionaryItemAppAuthorizationProvider"/>中对权限的定义.
    /// </summary>
   public static class DataDictionaryItemAppPermissions
    {
        /// <summary>
        /// 数据字典项管理权限
        /// </summary>
        public const string DataDictionaryItem = "Pages.DataDictionaryItem";

		/// <summary>
        /// 数据字典项管理创建权限
        /// </summary>
        public const string DataDictionaryItem_CreateDataDictionaryItem = "Pages.DataDictionaryItem.CreateDataDictionaryItem";

		/// <summary>
        /// 数据字典项管理修改权限
        /// </summary>
        public const string DataDictionaryItem_EditDataDictionaryItem = "Pages.DataDictionaryItem.EditDataDictionaryItem";

		/// <summary>
        /// 数据字典项管理删除权限
        /// </summary>
        public const string DataDictionaryItem_DeleteDataDictionaryItem = "Pages.DataDictionaryItem.DeleteDataDictionaryItem";
    }
}