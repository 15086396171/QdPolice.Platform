/*
* 命名空间 :     Vickn.Platform.PrivatePhoneWhites.Authorization
* 类 名  称 :     PrivatePhoneWhiteAppAuthorizationProvider
* 版      本 :      v1.0.0.0
* 文 件  名 :     PrivatePhoneWhiteAppAuthorizationProvider.cs
* 描      述 :      给个人白名单权限默认设置服务
* 创建时间 :     2018/2/23 14:15:09
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using System.Linq;
using Abp.Authorization;
using Abp.Localization;
using Vickn.Platform.Authorization;

namespace Vickn.Platform.PrivatePhoneWhites.Authorization
{
	/// <summary>
    /// 权限配置
    /// 给个人白名单权限默认设置服务
    /// See <see cref="PrivatePhoneWhiteAppPermissions"/> for all permission names.
	/// </summary>
    public class PrivatePhoneWhiteAppAuthorizationProvider : AuthorizationProvider
    {
	     /// <summary>
        /// This method is called once on application startup to allow to define permissions.
        /// </summary>
        /// <param name="context">Permission definition context</param>
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
		    //在这里配置了个人白名单的权限。

            var pages = context.GetPermissionOrNull(AppPermissions.Pages) ?? context.CreatePermission(AppPermissions.Pages, L("Pages"));

            var entityNameModel = pages.Children.FirstOrDefault(p => p.Name == AppPermissions.Pages_HandheldTerminal) 
                ?? pages.CreateChildPermission(AppPermissions.Pages_HandheldTerminal, L(AppPermissions.Pages_HandheldTerminal));

            var privatePhoneWhite = entityNameModel.CreateChildPermission(PrivatePhoneWhiteAppPermissions.PrivatePhoneWhite , L("PrivatePhoneWhite"));
            privatePhoneWhite.CreateChildPermission(PrivatePhoneWhiteAppPermissions.PrivatePhoneWhite_CreatePrivatePhoneWhite, L("CreatePrivatePhoneWhite"));
            privatePhoneWhite.CreateChildPermission(PrivatePhoneWhiteAppPermissions.PrivatePhoneWhite_EditPrivatePhoneWhite, L("EditPrivatePhoneWhite"));           
            privatePhoneWhite.CreateChildPermission(PrivatePhoneWhiteAppPermissions. PrivatePhoneWhite_DeletePrivatePhoneWhite, L("DeletePrivatePhoneWhite"));
		}

		private static ILocalizableString L(string name)
		{
            return new LocalizableString(name, PlatformConsts.LocalizationSourceName);
	    }
	}
}