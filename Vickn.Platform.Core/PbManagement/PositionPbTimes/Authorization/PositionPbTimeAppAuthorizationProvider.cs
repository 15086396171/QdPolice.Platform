/*
* 命名空间 :     Vickn.Platform.PbManagement.PositionPbTimes.Authorization
* 类 名  称 :     PositionPbTimeAppAuthorizationProvider
* 版      本 :      v1.0.0.0
* 文 件  名 :     PositionPbTimeAppAuthorizationProvider.cs
* 描      述 :      给当天上下班时间权限默认设置服务
* 创建时间 :     2018/5/8 14:06:13
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using System.Linq;
using Abp.Authorization;
using Abp.Localization;
using Vickn.Platform.Authorization;

namespace Vickn.Platform.PbManagement.PositionPbTimes.Authorization
{
	/// <summary>
    /// 权限配置
    /// 给当天上下班时间权限默认设置服务
    /// See <see cref="PositionPbTimeAppPermissions"/> for all permission names.
	/// </summary>
    public class PositionPbTimeAppAuthorizationProvider : AuthorizationProvider
    {
	     /// <summary>
        /// This method is called once on application startup to allow to define permissions.
        /// </summary>
        /// <param name="context">Permission definition context</param>
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
		    //在这里配置了当天上下班时间的权限。

            var pages = context.GetPermissionOrNull(AppPermissions.Pages) ?? context.CreatePermission(AppPermissions.Pages, L("Pages"));

            var entityNameModel = pages.Children.FirstOrDefault(p => p.Name == AppPermissions.Pages_PbManagement)
                         ?? pages.CreateChildPermission(AppPermissions.Pages_PbManagement, L(AppPermissions.Pages_PbManagement));

            var positionPbTime = entityNameModel.CreateChildPermission(PositionPbTimeAppPermissions.PositionPbTime , L("PositionPbTime"));
            positionPbTime.CreateChildPermission(PositionPbTimeAppPermissions.PositionPbTime_CreatePositionPbTime, L("CreatePositionPbTime"));
            positionPbTime.CreateChildPermission(PositionPbTimeAppPermissions.PositionPbTime_EditPositionPbTime, L("EditPositionPbTime"));           
            positionPbTime.CreateChildPermission(PositionPbTimeAppPermissions. PositionPbTime_DeletePositionPbTime, L("DeletePositionPbTime"));
		}

		private static ILocalizableString L(string name)
		{
            return new LocalizableString(name, PlatformConsts.LocalizationSourceName);
	    }
	}
}