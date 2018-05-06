/*
* 命名空间 :     Vickn.Platform.PbManagement.PbPositions.Authorization
* 类 名  称 :     PbPositionAppAuthorizationProvider
* 版      本 :      v1.0.0.0
* 文 件  名 :     PbPositionAppAuthorizationProvider.cs
* 描      述 :      给排班岗位权限默认设置服务
* 创建时间 :     2018/5/6 15:05:46
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using System.Linq;
using Abp.Authorization;
using Abp.Localization;
using Vickn.Platform.Authorization;

namespace Vickn.Platform.PbManagement.PbPositions.Authorization
{
	/// <summary>
    /// 权限配置
    /// 给排班岗位权限默认设置服务
    /// See <see cref="PbPositionAppPermissions"/> for all permission names.
	/// </summary>
    public class PbPositionAppAuthorizationProvider : AuthorizationProvider
    {
	     /// <summary>
        /// This method is called once on application startup to allow to define permissions.
        /// </summary>
        /// <param name="context">Permission definition context</param>
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
		    //在这里配置了排班岗位的权限。

            var pages = context.GetPermissionOrNull(AppPermissions.Pages) ?? context.CreatePermission(AppPermissions.Pages, L("Pages"));

            var entityNameModel = pages.Children.FirstOrDefault(p => p.Name == AppPermissions.Pages_PbManagement) 
                ?? pages.CreateChildPermission(AppPermissions.Pages_PbManagement, L(AppPermissions.Pages_PbManagement));

            var pbPosition = entityNameModel.CreateChildPermission(PbPositionAppPermissions.PbPosition , L("PbPosition"));
            pbPosition.CreateChildPermission(PbPositionAppPermissions.PbPosition_CreatePbPosition, L("CreatePbPosition"));
            pbPosition.CreateChildPermission(PbPositionAppPermissions.PbPosition_EditPbPosition, L("EditPbPosition"));           
            pbPosition.CreateChildPermission(PbPositionAppPermissions. PbPosition_DeletePbPosition, L("DeletePbPosition"));
		}

		private static ILocalizableString L(string name)
		{
            return new LocalizableString(name, PlatformConsts.LocalizationSourceName);
	    }
	}
}