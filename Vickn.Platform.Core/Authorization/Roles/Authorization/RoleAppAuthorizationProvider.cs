/*
* 命名空间 :     Vickn.Platform.Authorization.Roles.Authorization
* 类 名  称 :     RoleAppAuthorizationProvider
* 版      本 :      v1.0.0.0
* 文 件  名 :     RoleAppAuthorizationProvider.cs
* 描      述 :      给角色权限默认设置服务
* 创建时间 :     2017/2/20 15:46:59
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using System.Linq;
using Abp.Authorization;
using Abp.Localization;
using Vickn.Platform.Authorization;

namespace Vickn.Platform.Authorization.Roles.Authorization
{
	/// <summary>
    /// 权限配置
    /// 给角色权限默认设置服务
    /// See <see cref="RoleAppPermissions"/> for all permission names.
	/// </summary>
    public class RoleAppAuthorizationProvider : AuthorizationProvider
    {
	     /// <summary>
        /// This method is called once on application startup to allow to define permissions.
        /// </summary>
        /// <param name="context">Permission definition context</param>
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
		    //在这里配置了角色的权限。

            var pages = context.GetPermissionOrNull(AppPermissions.Pages) ?? context.CreatePermission(AppPermissions.Pages, L("Pages"));

            var entityNameModel = pages.Children.FirstOrDefault(p => p.Name == AppPermissions.Pages_Administration) 
                ?? pages.CreateChildPermission(AppPermissions.Pages_Administration, L("Administration"));

            var role = entityNameModel.CreateChildPermission(RoleAppPermissions.Role , L("Role"));
            role.CreateChildPermission(RoleAppPermissions.Role_CreateRole, L("CreateRole"));
            role.CreateChildPermission(RoleAppPermissions.Role_EditRole, L("EditRole"));           
            role.CreateChildPermission(RoleAppPermissions. Role_DeleteRole, L("DeleteRole"));
		}

		private static ILocalizableString L(string name)
		{
            return new LocalizableString(name, PlatformConsts.LocalizationSourceName);
	    }
	}
}