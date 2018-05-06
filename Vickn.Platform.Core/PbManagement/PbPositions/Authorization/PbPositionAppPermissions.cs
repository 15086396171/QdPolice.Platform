/*
* 命名空间 :     Vickn.Platform.PbManagement.PbPositions.Authorization
* 类 名  称 :     PbPositionAppPermissions
* 版      本 :      v1.0.0.0
* 文 件  名 :     PbPositionAppPermissions.cs
* 描      述 :      定义系统的权限名称的字符串常量
* 创建时间 :     2018/5/6 15:05:47
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

namespace Vickn.Platform.PbManagement.PbPositions.Authorization
{
	/// <summary>
	/// 定义系统的权限名称的字符串常量。
    /// <see cref="PbPositionAppAuthorizationProvider"/>中对权限的定义.
    /// </summary>
   public static class PbPositionAppPermissions
    {
        /// <summary>
        /// 排班岗位管理权限
        /// </summary>
        public const string PbPosition = "Pages.PbPosition";

		/// <summary>
        /// 排班岗位管理创建权限
        /// </summary>
        public const string PbPosition_CreatePbPosition = "Pages.PbPosition.CreatePbPosition";

		/// <summary>
        /// 排班岗位管理修改权限
        /// </summary>
        public const string PbPosition_EditPbPosition = "Pages.PbPosition.EditPbPosition";

		/// <summary>
        /// 排班岗位管理删除权限
        /// </summary>
        public const string PbPosition_DeletePbPosition = "Pages.PbPosition.DeletePbPosition";
    }
}