/*
* 命名空间 :     Vickn.Platform.Schedules.PlatoonGroups.Authorization
* 类 名  称 :     PlatoonGroupAppAuthorizationProvider
* 版      本 :      v1.0.0.0
* 文 件  名 :     PlatoonGroupAppAuthorizationProvider.cs
* 描      述 :      给排班组权限默认设置服务
* 创建时间 :     2018/5/4 15:19:42
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using System.Linq;
using Abp.Authorization;
using Abp.Localization;
using Vickn.Platform.Authorization;

namespace Vickn.Platform.Schedules.PlatoonGroups.Authorization
{
	/// <summary>
    /// 权限配置
    /// 给排班组权限默认设置服务
    /// See <see cref="PlatoonGroupAppPermissions"/> for all permission names.
	/// </summary>
    public class PlatoonGroupAppAuthorizationProvider : AuthorizationProvider
    {
	     /// <summary>
        /// This method is called once on application startup to allow to define permissions.
        /// </summary>
        /// <param name="context">Permission definition context</param>
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
		    //在这里配置了排班组的权限。

            var pages = context.GetPermissionOrNull(AppPermissions.Pages) ?? context.CreatePermission(AppPermissions.Pages, L("Pages"));

            var entityNameModel = pages.Children.FirstOrDefault(p => p.Name == AppPermissions.Pages_ScheduleManage)
              ?? pages.CreateChildPermission(AppPermissions.Pages_ScheduleManage, L(AppPermissions.Pages_ScheduleManage));


            var platoonGroup = entityNameModel.CreateChildPermission(PlatoonGroupAppPermissions.PlatoonGroup , L("PlatoonGroup"));
            platoonGroup.CreateChildPermission(PlatoonGroupAppPermissions.PlatoonGroup_CreatePlatoonGroup, L("CreatePlatoonGroup"));
            platoonGroup.CreateChildPermission(PlatoonGroupAppPermissions.PlatoonGroup_EditPlatoonGroup, L("EditPlatoonGroup"));           
            platoonGroup.CreateChildPermission(PlatoonGroupAppPermissions. PlatoonGroup_DeletePlatoonGroup, L("DeletePlatoonGroup"));
		}

		private static ILocalizableString L(string name)
		{
            return new LocalizableString(name, PlatformConsts.LocalizationSourceName);
	    }
	}
}