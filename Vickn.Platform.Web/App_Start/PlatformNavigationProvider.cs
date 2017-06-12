using Abp.Application.Navigation;
using Abp.Localization;
using Vickn.Platform.AuditLogs.Authorization;
using Vickn.Platform.Authorization;
using Vickn.Platform.Authorization.Roles.Authorization;
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
            context.Manager.MainMenu
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
                        requiredPermissionName: RoleAppPermissions.Role
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
                        ))) // end:SystemManage

            #endregion

                ;
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, PlatformConsts.LocalizationSourceName);
        }
    }
}
