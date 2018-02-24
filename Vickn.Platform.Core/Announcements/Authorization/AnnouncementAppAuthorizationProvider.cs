/*
* 命名空间 :     Vickn.Platform.Announcements.Authorization
* 类 名  称 :     AnnouncementAppAuthorizationProvider
* 版      本 :      v1.0.0.0
* 文 件  名 :     AnnouncementAppAuthorizationProvider.cs
* 描      述 :      给通知公告权限默认设置服务
* 创建时间 :     2018/2/24 11:42:46
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using System.Linq;
using Abp.Authorization;
using Abp.Localization;
using Vickn.Platform.Authorization;

namespace Vickn.Platform.Announcements.Authorization
{
	/// <summary>
    /// 权限配置
    /// 给通知公告权限默认设置服务
    /// See <see cref="AnnouncementAppPermissions"/> for all permission names.
	/// </summary>
    public class AnnouncementAppAuthorizationProvider : AuthorizationProvider
    {
	     /// <summary>
        /// This method is called once on application startup to allow to define permissions.
        /// </summary>
        /// <param name="context">Permission definition context</param>
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
		    //在这里配置了通知公告的权限。

            var pages = context.GetPermissionOrNull(AppPermissions.Pages) ?? context.CreatePermission(AppPermissions.Pages, L("Pages"));

            var entityNameModel = pages.Children.FirstOrDefault(p => p.Name == AppPermissions.Pages_HandheldTerminal) 
                ?? pages.CreateChildPermission(AppPermissions.Pages_HandheldTerminal, L(AppPermissions.Pages_HandheldTerminal));

            var announcement = entityNameModel.CreateChildPermission(AnnouncementAppPermissions.Announcement , L("Announcement"));
            announcement.CreateChildPermission(AnnouncementAppPermissions.Announcement_CreateAnnouncement, L("CreateAnnouncement"));
            announcement.CreateChildPermission(AnnouncementAppPermissions.Announcement_EditAnnouncement, L("EditAnnouncement"));           
            announcement.CreateChildPermission(AnnouncementAppPermissions. Announcement_DeleteAnnouncement, L("DeleteAnnouncement"));
		}

		private static ILocalizableString L(string name)
		{
            return new LocalizableString(name, PlatformConsts.LocalizationSourceName);
	    }
	}
}