/*
* 命名空间 :     Vickn.Platform.DataDictionaries.Authorization
* 类 名  称 :     DataDictionaryItemAppAuthorizationProvider
* 版      本 :      v1.0.0.0
* 文 件  名 :     DataDictionaryItemAppAuthorizationProvider.cs
* 描      述 :      给数据字典项权限默认设置服务
* 创建时间 :     2017/6/12 16:57:18
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using System.Linq;
using Abp.Authorization;
using Abp.Localization;
using Vickn.Platform.Authorization;

namespace Vickn.Platform.DataDictionaries.Authorization
{
	/// <summary>
    /// 权限配置
    /// 给数据字典项权限默认设置服务
    /// See <see cref="DataDictionaryItemAppPermissions"/> for all permission names.
	/// </summary>
    public class DataDictionaryItemAppAuthorizationProvider : AuthorizationProvider
    {
	     /// <summary>
        /// This method is called once on application startup to allow to define permissions.
        /// </summary>
        /// <param name="context">Permission definition context</param>
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
		    //在这里配置了数据字典项的权限。

            var pages = context.GetPermissionOrNull(AppPermissions.Pages) ?? context.CreatePermission(AppPermissions.Pages, L("Pages"));

            var entityNameModel = pages.Children.FirstOrDefault(p => p.Name == AppPermissions.Pages_SystemManage)
          ?? pages.CreateChildPermission(AppPermissions.Pages_SystemManage, L("SystemManage"));

            var dataDictionaryItem = entityNameModel.CreateChildPermission(DataDictionaryItemAppPermissions.DataDictionaryItem , L("DataDictionaryItem"));
            dataDictionaryItem.CreateChildPermission(DataDictionaryItemAppPermissions.DataDictionaryItem_CreateDataDictionaryItem, L("CreateDataDictionaryItem"));
            dataDictionaryItem.CreateChildPermission(DataDictionaryItemAppPermissions.DataDictionaryItem_EditDataDictionaryItem, L("EditDataDictionaryItem"));           
            dataDictionaryItem.CreateChildPermission(DataDictionaryItemAppPermissions. DataDictionaryItem_DeleteDataDictionaryItem, L("DeleteDataDictionaryItem"));
		}

		private static ILocalizableString L(string name)
		{
            return new LocalizableString(name, PlatformConsts.LocalizationSourceName);
	    }
	}
}