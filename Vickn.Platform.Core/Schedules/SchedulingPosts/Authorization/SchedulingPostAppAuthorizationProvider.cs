/*
* 命名空间 :     Vickn.Platform.Schedules.SchedulingPosts.Authorization
* 类 名  称 :     SchedulingPostAppAuthorizationProvider
* 版      本 :      v1.0.0.0
* 文 件  名 :     SchedulingPostAppAuthorizationProvider.cs
* 描      述 :      给岗位设置权限默认设置服务
* 创建时间 :     2018/5/3 15:40:47
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using System.Linq;
using Abp.Authorization;
using Abp.Localization;
using Vickn.Platform.Authorization;

namespace Vickn.Platform.Schedules.SchedulingPosts.Authorization
{
	/// <summary>
    /// 权限配置
    /// 给岗位设置权限默认设置服务
    /// See <see cref="SchedulingPostAppPermissions"/> for all permission names.
	/// </summary>
    public class SchedulingPostAppAuthorizationProvider : AuthorizationProvider
    {
	     /// <summary>
        /// This method is called once on application startup to allow to define permissions.
        /// </summary>
        /// <param name="context">Permission definition context</param>
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
		    //在这里配置了岗位设置的权限。

            var pages = context.GetPermissionOrNull(AppPermissions.Pages) ?? context.CreatePermission(AppPermissions.Pages, L("Pages"));

            var entityNameModel = pages.Children.FirstOrDefault(p => p.Name == AppPermissions.Pages_ScheduleManage) 
                ?? pages.CreateChildPermission(AppPermissions.Pages_ScheduleManage, L(AppPermissions.Pages_ScheduleManage));

          

            var schedulingPost = entityNameModel.CreateChildPermission(SchedulingPostAppPermissions.SchedulingPost , L("SchedulingPost"));
            schedulingPost.CreateChildPermission(SchedulingPostAppPermissions.SchedulingPost_CreateSchedulingPost, L("CreateSchedulingPost"));
            schedulingPost.CreateChildPermission(SchedulingPostAppPermissions.SchedulingPost_EditSchedulingPost, L("EditSchedulingPost"));           
            schedulingPost.CreateChildPermission(SchedulingPostAppPermissions. SchedulingPost_DeleteSchedulingPost, L("DeleteSchedulingPost"));
		}

		private static ILocalizableString L(string name)
		{
            return new LocalizableString(name, PlatformConsts.LocalizationSourceName);
	    }
	}
}