/*
* 命名空间 :     Vickn.Platform.Schedules.SchedulingPosts.Authorization
* 类 名  称 :     SchedulingPostAppPermissions
* 版      本 :      v1.0.0.0
* 文 件  名 :     SchedulingPostAppPermissions.cs
* 描      述 :      定义系统的权限名称的字符串常量
* 创建时间 :     2018/5/3 15:40:49
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

namespace Vickn.Platform.Schedules.SchedulingPosts.Authorization
{
	/// <summary>
	/// 定义系统的权限名称的字符串常量。
    /// <see cref="SchedulingPostAppAuthorizationProvider"/>中对权限的定义.
    /// </summary>
   public static class SchedulingPostAppPermissions
    {
        /// <summary>
        /// 岗位设置管理权限
        /// </summary>
        public const string SchedulingPost = "Pages.SchedulingPost";

		/// <summary>
        /// 岗位设置管理创建权限
        /// </summary>
        public const string SchedulingPost_CreateSchedulingPost = "Pages.SchedulingPost.CreateSchedulingPost";

		/// <summary>
        /// 岗位设置管理修改权限
        /// </summary>
        public const string SchedulingPost_EditSchedulingPost = "Pages.SchedulingPost.EditSchedulingPost";

		/// <summary>
        /// 岗位设置管理删除权限
        /// </summary>
        public const string SchedulingPost_DeleteSchedulingPost = "Pages.SchedulingPost.DeleteSchedulingPost";
    }
}