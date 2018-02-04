using Abp.Application.Navigation;
using Abp.Localization;
using Vickn.Platform.AuditLogs.Authorization;
using Vickn.Platform.Authorization;
using Vickn.Platform.Authorization.Roles.Authorization;
using Vickn.Platform.DataDictionaries.Authorization;
using Vickn.Platform.HandheldTerminals.Devices.Authorization;
using Vickn.Platform.OrganizationUnits.Authorization;
using Vickn.Platform.Users.Authorization;

namespace Vickn.Platform.Web
{
    /// <summary>
    /// This class defines menus for the application.
    /// It uses ABP's menu system.
    /// When you add menu items here, they are automatically appear in angular application.
    /// See Views/Layout/_TopMenu.cshtml file to know how to render menu.
    /// </summary>
    public class PlatformNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            var device = new MenuItemDefinition(
                AppPermissions.Pages_HandheldTerminal,
                L(AppPermissions.Pages_HandheldTerminal),
                icon: "icon-grid"
            );

            device.AddItem(
                new MenuItemDefinition(
                    DeviceAppPermissions.Device,
                    L("Device"),
                    "icon-star",
                    url: "/Devices/Device",
                    requiredPermissionName: DeviceAppPermissions.Device));


            context.Manager.MainMenu
                .AddItem(device)

            #region 系统管理
                .AddItem(
                    new MenuItemDefinition(
                        "SystemManage",
                        L("SystemManage"),
                        icon: "fa fa-gear",
                        requiredPermissionName: AppPermissions.Pages_SystemManage
                        )
                        .AddItem(
                    new MenuItemDefinition(
                        "User",
                        L("User"),
                        url: "Users",
                        requiredPermissionName: UserAppPermissions.User
                        ))
                         .AddItem(
                    new MenuItemDefinition(
                        "Role",
                        L("Role"),
                        url: "Roles",
                        requiredPermissionName: RoleAppPermissions.Role
                        ))
                          .AddItem(
                    new MenuItemDefinition(
                        "OrganizationUnit",
                        L("OrganizationUnit"),
                        url: "OrganizationUnits",
                        requiredPermissionName: OrganizationUnitAppPermissions.OrganizationUnit
                        ))
                        .AddItem(
                    new MenuItemDefinition(
                        "DataDictionaries",
                        L("DataDictionary"),
                        url: "DataDictionaries",
                        requiredPermissionName: DataDictionaryAppPermissions.DataDictionary
                        ))
                    .AddItem(
                    new MenuItemDefinition(
                        "AuditLog",
                        L("AuditLog"),
                        url: "AuditLogs",
                        requiredPermissionName: AuditLogAppPermissions.AuditLog
                        ))
                        .AddItem(
                    new MenuItemDefinition(
                        "MainTenance",
                        L("Maintenance"),
                        url: "MainTenance",
                        requiredPermissionName: AppPermissions.Pages_Maintenance
                        ))
                                            .AddItem(
                    new MenuItemDefinition(
                        "DatatableApi",
                        L("DatatableApi"),
                        url: "Document/DataTable",
                        requiredPermissionName: AppPermissions.Pages_Api
                        ))
                        ) // end:SystemManage

            #endregion

                ;
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, PlatformConsts.LocalizationSourceName);
        }
    }
}
