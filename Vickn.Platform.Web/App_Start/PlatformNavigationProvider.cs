using Abp.Application.Navigation;
using Abp.Localization;
using Vickn.Platform.Authorization;

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
                        "Users",
                        L("系统管理"),
                        icon: "fa fa-users",
                        requiredPermissionName: AppPermissions.Pages_Users
                        )
                        .AddItem(
                    new MenuItemDefinition(
                        "Users",
                        L("用户管理"),
                        url: "Users",
                        icon: "fa fa-users",
                        requiredPermissionName: AppPermissions.Pages_Users
                        ))
                          )
                .AddItem(
                    new MenuItemDefinition(
                        "About",
                        L("关于"),
                        url: "About",
                        icon: "fa fa-info"
                        )
                );
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, PlatformConsts.LocalizationSourceName);
        }
    }
}
