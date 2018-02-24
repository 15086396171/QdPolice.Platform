/*
* 命名空间 :     Vickn.Platform.Announcements.Authorization
* 类 名  称 :     AnnouncementAppPermissions
* 版      本 :      v1.0.0.0
* 文 件  名 :     AnnouncementAppPermissions.cs
* 描      述 :      定义系统的权限名称的字符串常量
* 创建时间 :     2018/2/24 11:42:55
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

namespace Vickn.Platform.Announcements.Authorization
{
	/// <summary>
	/// 定义系统的权限名称的字符串常量。
    /// <see cref="AnnouncementAppAuthorizationProvider"/>中对权限的定义.
    /// </summary>
   public static class AnnouncementAppPermissions
    {
        /// <summary>
        /// 通知公告管理权限
        /// </summary>
        public const string Announcement = "Pages.Announcement";

		/// <summary>
        /// 通知公告管理创建权限
        /// </summary>
        public const string Announcement_CreateAnnouncement = "Pages.Announcement.CreateAnnouncement";

		/// <summary>
        /// 通知公告管理修改权限
        /// </summary>
        public const string Announcement_EditAnnouncement = "Pages.Announcement.EditAnnouncement";

		/// <summary>
        /// 通知公告管理删除权限
        /// </summary>
        public const string Announcement_DeleteAnnouncement = "Pages.Announcement.DeleteAnnouncement";
    }
}