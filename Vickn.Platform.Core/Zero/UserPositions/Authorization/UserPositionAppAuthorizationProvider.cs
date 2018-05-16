/*
* 命名空间 :     Vickn.Platform.Zero.UserPositions.Authorization
* 类 名  称 :     UserPositionAppAuthorizationProvider
* 版      本 :      v1.0.0.0
* 文 件  名 :     UserPositionAppAuthorizationProvider.cs
* 描      述 :      给职位信息权限默认设置服务
* 创建时间 :     2018/5/16 9:57:47
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using System.Linq;
using Abp.Authorization;
using Abp.Localization;
using Vickn.Platform.Authorization;

namespace Vickn.Platform.Zero.UserPositions.Authorization
{
	/// <summary>
    /// 权限配置
    /// 给职位信息权限默认设置服务
    /// See <see cref="UserPositionAppPermissions"/> for all permission names.
	/// </summary>
    public class UserPositionAppAuthorizationProvider : AuthorizationProvider
    {
	     /// <summary>
        /// This method is called once on application startup to allow to define permissions.
        /// </summary>
        /// <param name="context">Permission definition context</param>
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
		    //在这里配置了职位信息的权限。

            var pages = context.GetPermissionOrNull(AppPermissions.Pages) ?? context.CreatePermission(AppPermissions.Pages, L("Pages"));

            var entityNameModel = pages.Children.FirstOrDefault(p => p.Name == AppPermissions.Pages_SystemManage) 
                ?? pages.CreateChildPermission(AppPermissions.Pages_SystemManage, L("SystemManage"));

            var userPosition = entityNameModel.CreateChildPermission(UserPositionAppPermissions.UserPosition , L("UserPosition"));
            userPosition.CreateChildPermission(UserPositionAppPermissions.UserPosition_CreateUserPosition, L("CreateUserPosition"));
            userPosition.CreateChildPermission(UserPositionAppPermissions.UserPosition_EditUserPosition, L("EditUserPosition"));           
            userPosition.CreateChildPermission(UserPositionAppPermissions. UserPosition_DeleteUserPosition, L("DeleteUserPosition"));
		}

		private static ILocalizableString L(string name)
		{
            return new LocalizableString(name, PlatformConsts.LocalizationSourceName);
	    }
	}
}