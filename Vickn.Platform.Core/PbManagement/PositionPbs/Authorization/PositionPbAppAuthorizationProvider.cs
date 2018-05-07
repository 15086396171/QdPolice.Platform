/*
* 命名空间 :     Vickn.Platform.PbManagement.PositionPbs.Authorization
* 类 名  称 :     PositionPbAppAuthorizationProvider
* 版      本 :      v1.0.0.0
* 文 件  名 :     PositionPbAppAuthorizationProvider.cs
* 描      述 :      给单个岗位下排班时间权限默认设置服务
* 创建时间 :     2018/5/7 13:34:37
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using System.Linq;
using Abp.Authorization;
using Abp.Localization;
using Vickn.Platform.Authorization;

namespace Vickn.Platform.PbManagement.PositionPbs.Authorization
{
	/// <summary>
    /// 权限配置
    /// 给单个岗位下排班时间权限默认设置服务
    /// See <see cref="PositionPbAppPermissions"/> for all permission names.
	/// </summary>
    public class PositionPbAppAuthorizationProvider : AuthorizationProvider
    {
	     /// <summary>
        /// This method is called once on application startup to allow to define permissions.
        /// </summary>
        /// <param name="context">Permission definition context</param>
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
		    //在这里配置了单个岗位下排班时间的权限。

            var pages = context.GetPermissionOrNull(AppPermissions.Pages) ?? context.CreatePermission(AppPermissions.Pages, L("Pages"));

            var entityNameModel = pages.Children.FirstOrDefault(p => p.Name == AppPermissions.Pages) 
                ?? pages.CreateChildPermission(AppPermissions.Pages, L("Pages"));

            var positionPb = entityNameModel.CreateChildPermission(PositionPbAppPermissions.PositionPb , L("PositionPb"));
            positionPb.CreateChildPermission(PositionPbAppPermissions.PositionPb_CreatePositionPb, L("CreatePositionPb"));
            positionPb.CreateChildPermission(PositionPbAppPermissions.PositionPb_EditPositionPb, L("EditPositionPb"));           
            positionPb.CreateChildPermission(PositionPbAppPermissions. PositionPb_DeletePositionPb, L("DeletePositionPb"));
		}

		private static ILocalizableString L(string name)
		{
            return new LocalizableString(name, PlatformConsts.LocalizationSourceName);
	    }
	}
}