using Abp.Application.Navigation;
using Abp.Localization;
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
                .AddItem(
                    new MenuItemDefinition(
                        "Tenants",
                        L("租户管理"),
                        url: "Tenants",
                        icon: "fa fa-globe",
                        requiredPermissionName: AppPermissions.Pages_Tenants
                        ))
                .AddItem(
                    new MenuItemDefinition(
                        "SystemManage",
                        L("SystemManage"),
                        icon: "Hui-iconfont-system",
                        requiredPermissionName: AppPermissions.Pages_SystemManage
                        )
                        .AddItem(
                    new MenuItemDefinition(
                        "User",
                        L("User"),
                        url: "Users",
                        icon: "fa fa-users",
                        requiredPermissionName: UserAppPermissions.User
                        ))
                         .AddItem(
                    new MenuItemDefinition(
                        "Role",
                        L("Role"),
                        url: "Roles",
                        icon: "fa fa-users",
                        requiredPermissionName: RoleAppPermissions.Role
                        ))
                          .AddItem(
                    new MenuItemDefinition(
                        "OrganizationUnit",
                        L("OrganizationUnit"),
                        url: "OrganizationUnits",
                        icon: "fa fa-users",
                        requiredPermissionName: RoleAppPermissions.Role
                        ))
                    .AddItem(
                    new MenuItemDefinition(
                        "AuditLog",
                        L("AuditLog"),
                        url: "AuditLogs",
                        icon: "fa fa-users",
                        requiredPermissionName: RoleAppPermissions.Role
                        ))

                        ) // end:SystemManage
                ;
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, PlatformConsts.LocalizationSourceName);
        }
    }
}
