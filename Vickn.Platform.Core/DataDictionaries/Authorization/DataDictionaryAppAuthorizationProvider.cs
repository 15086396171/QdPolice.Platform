/*
* 命名空间 :     Vickn.Platform.DataDictionaries.Authorization
* 类 名  称 :     DataDictionaryAppAuthorizationProvider
* 版      本 :      v1.0.0.0
* 文 件  名 :     DataDictionaryAppAuthorizationProvider.cs
* 描      述 :      给数据字典权限默认设置服务
* 创建时间 :     2017/6/12 16:41:29
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
    /// 给数据字典权限默认设置服务
    /// See <see cref="DataDictionaryAppPermissions"/> for all permission names.
    /// </summary>
    public class DataDictionaryAppAuthorizationProvider : AuthorizationProvider
    {
        /// <summary>
        /// This method is called once on application startup to allow to define permissions.
        /// </summary>
        /// <param name="context">Permission definition context</param>
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            //在这里配置了数据字典的权限。

            var pages = context.GetPermissionOrNull(AppPermissions.Pages) ?? context.CreatePermission(AppPermissions.Pages, L("Pages"));

            var entityNameModel = pages.Children.FirstOrDefault(p => p.Name == AppPermissions.Pages_SystemManage)
           ?? pages.CreateChildPermission(AppPermissions.Pages_SystemManage, L("SystemManage"));

            var dataDictionary = entityNameModel.CreateChildPermission(DataDictionaryAppPermissions.DataDictionary, L("DataDictionary"));
            dataDictionary.CreateChildPermission(DataDictionaryAppPermissions.DataDictionary_CreateDataDictionary, L("CreateDataDictionary"));
            dataDictionary.CreateChildPermission(DataDictionaryAppPermissions.DataDictionary_EditDataDictionary, L("EditDataDictionary"));
            dataDictionary.CreateChildPermission(DataDictionaryAppPermissions.DataDictionary_DeleteDataDictionary, L("DeleteDataDictionary"));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, PlatformConsts.LocalizationSourceName);
        }
    }
}