/*
* 命名空间 :     Vickn.Platform.HandheldTerminals.Devices.Authorization
* 类 名  称 :     DeviceAppAuthorizationProvider
* 版      本 :      v1.0.0.0
* 文 件  名 :     DeviceAppAuthorizationProvider.cs
* 描      述 :      给设备权限默认设置服务
* 创建时间 :     2018/2/4 16:27:00
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using System.Linq;
using Abp.Authorization;
using Abp.Localization;
using Vickn.Platform.Authorization;

namespace Vickn.Platform.HandheldTerminals.Devices.Authorization
{
	/// <summary>
    /// 权限配置
    /// 给设备权限默认设置服务
    /// See <see cref="DeviceAppPermissions"/> for all permission names.
	/// </summary>
    public class DeviceAppAuthorizationProvider : AuthorizationProvider
    {
	     /// <summary>
        /// This method is called once on application startup to allow to define permissions.
        /// </summary>
        /// <param name="context">Permission definition context</param>
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
		    //在这里配置了设备的权限。

            var pages = context.GetPermissionOrNull(AppPermissions.Pages) ?? context.CreatePermission(AppPermissions.Pages, L("Pages"));

            var entityNameModel = pages.Children.FirstOrDefault(p => p.Name == AppPermissions.Pages) 
                ?? pages.CreateChildPermission(AppPermissions.Pages_HandheldTerminal, L(AppPermissions.Pages_HandheldTerminal));

            var device = entityNameModel.CreateChildPermission(DeviceAppPermissions.Device , L("Device"));
            device.CreateChildPermission(DeviceAppPermissions.Device_CreateDevice, L("CreateDevice"));
            device.CreateChildPermission(DeviceAppPermissions.Device_EditDevice, L("EditDevice"));           
            device.CreateChildPermission(DeviceAppPermissions. Device_DeleteDevice, L("DeleteDevice"));
		}

		private static ILocalizableString L(string name)
		{
            return new LocalizableString(name, PlatformConsts.LocalizationSourceName);
	    }
	}
}