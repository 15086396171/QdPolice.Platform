/*
* 命名空间 :     Vickn.Platform.Zero.UserPositions.Authorization
* 类 名  称 :     UserPositionAppPermissions
* 版      本 :      v1.0.0.0
* 文 件  名 :     UserPositionAppPermissions.cs
* 描      述 :      定义系统的权限名称的字符串常量
* 创建时间 :     2018/5/16 9:57:48
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

namespace Vickn.Platform.Zero.UserPositions.Authorization
{
	/// <summary>
	/// 定义系统的权限名称的字符串常量。
    /// <see cref="UserPositionAppAuthorizationProvider"/>中对权限的定义.
    /// </summary>
   public static class UserPositionAppPermissions
    {
        /// <summary>
        /// 职位信息管理权限
        /// </summary>
        public const string UserPosition = "Pages.UserPosition";

		/// <summary>
        /// 职位信息管理创建权限
        /// </summary>
        public const string UserPosition_CreateUserPosition = "Pages.UserPosition.CreateUserPosition";

		/// <summary>
        /// 职位信息管理修改权限
        /// </summary>
        public const string UserPosition_EditUserPosition = "Pages.UserPosition.EditUserPosition";

		/// <summary>
        /// 职位信息管理删除权限
        /// </summary>
        public const string UserPosition_DeleteUserPosition = "Pages.UserPosition.DeleteUserPosition";
    }
}