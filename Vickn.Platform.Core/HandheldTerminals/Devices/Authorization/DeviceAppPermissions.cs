/*
* 命名空间 :     Vickn.Platform.HandheldTerminals.Devices.Authorization
* 类 名  称 :     DeviceAppPermissions
* 版      本 :      v1.0.0.0
* 文 件  名 :     DeviceAppPermissions.cs
* 描      述 :      定义系统的权限名称的字符串常量
* 创建时间 :     2018/2/4 16:27:01
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

namespace Vickn.Platform.HandheldTerminals.Devices.Authorization
{
	/// <summary>
	/// 定义系统的权限名称的字符串常量。
    /// <see cref="DeviceAppAuthorizationProvider"/>中对权限的定义.
    /// </summary>
   public static class DeviceAppPermissions
    {
        /// <summary>
        /// 设备管理权限
        /// </summary>
        public const string Device = "Pages.Device";

		/// <summary>
        /// 设备管理创建权限
        /// </summary>
        public const string Device_CreateDevice = "Pages.Device.CreateDevice";

		/// <summary>
        /// 设备管理修改权限
        /// </summary>
        public const string Device_EditDevice = "Pages.Device.EditDevice";

		/// <summary>
        /// 设备管理删除权限
        /// </summary>
        public const string Device_DeleteDevice = "Pages.Device.DeleteDevice";
    }
}