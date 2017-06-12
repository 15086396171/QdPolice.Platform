/*
* 命名空间 :     Vickn.Platform.DataDictionaries.Authorization
* 类 名  称 :     DataDictionaryAppPermissions
* 版      本 :      v1.0.0.0
* 文 件  名 :     DataDictionaryAppPermissions.cs
* 描      述 :      定义系统的权限名称的字符串常量
* 创建时间 :     2017/6/12 16:41:29
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

namespace Vickn.Platform.DataDictionaries.Authorization
{
	/// <summary>
	/// 定义系统的权限名称的字符串常量。
    /// <see cref="DataDictionaryAppAuthorizationProvider"/>中对权限的定义.
    /// </summary>
   public static class DataDictionaryAppPermissions
    {
        /// <summary>
        /// 数据字典管理权限
        /// </summary>
        public const string DataDictionary = "Pages.DataDictionary";

		/// <summary>
        /// 数据字典管理创建权限
        /// </summary>
        public const string DataDictionary_CreateDataDictionary = "Pages.DataDictionary.CreateDataDictionary";

		/// <summary>
        /// 数据字典管理修改权限
        /// </summary>
        public const string DataDictionary_EditDataDictionary = "Pages.DataDictionary.EditDataDictionary";

		/// <summary>
        /// 数据字典管理删除权限
        /// </summary>
        public const string DataDictionary_DeleteDataDictionary = "Pages.DataDictionary.DeleteDataDictionary";
    }
}