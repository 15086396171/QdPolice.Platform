/*
* 命名空间 :     Vickn.Platform.HandheldTerminals.AppWhiteLists.Authorization
* 类 名  称 :     AppWhiteListAppAuthorizationProvider
* 版      本 :      v1.0.0.0
* 文 件  名 :     AppWhiteListAppAuthorizationProvider.cs
* 描      述 :      给应用白名单权限默认设置服务
* 创建时间 :     2018/2/5 15:11:31
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using System.Linq;
using Abp.Authorization;
using Abp.Localization;
using Vickn.Platform.Authorization;

namespace Vickn.Platform.HandheldTerminals.AppWhiteLists.Authorization
{
	/// <summary>
    /// 权限配置
    /// 给应用白名单权限默认设置服务
    /// See <see cref="AppWhiteListAppPermissions"/> for all permission names.
	/// </summary>
    public class AppWhiteListAppAuthorizationProvider : AuthorizationProvider
    {
	     /// <summary>
        /// This method is called once on application startup to allow to define permissions.
        /// </summary>
        /// <param name="context">Permission definition context</param>
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
		    //在这里配置了应用白名单的权限。

            var pages = context.GetPermissionOrNull(AppPermissions.Pages) ?? context.CreatePermission(AppPermissions.Pages, L("Pages"));

            var entityNameModel = pages.Children.FirstOrDefault(p => p.Name == AppPermissions.Pages_HandheldTerminal) 
                ?? pages.CreateChildPermission(AppPermissions.Pages_HandheldTerminal, L(AppPermissions.Pages_HandheldTerminal));

            var appWhiteList = entityNameModel.CreateChildPermission(AppWhiteListAppPermissions.AppWhiteList , L("AppWhiteList"));
            appWhiteList.CreateChildPermission(AppWhiteListAppPermissions.AppWhiteList_CreateAppWhiteList, L("CreateAppWhiteList"));
            appWhiteList.CreateChildPermission(AppWhiteListAppPermissions.AppWhiteList_EditAppWhiteList, L("EditAppWhiteList"));           
            appWhiteList.CreateChildPermission(AppWhiteListAppPermissions. AppWhiteList_DeleteAppWhiteList, L("DeleteAppWhiteList"));
		}

		private static ILocalizableString L(string name)
		{
            return new LocalizableString(name, PlatformConsts.LocalizationSourceName);
	    }
	}
}