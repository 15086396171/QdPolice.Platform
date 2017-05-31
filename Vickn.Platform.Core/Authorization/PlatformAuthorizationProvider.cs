using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace Vickn.Platform.Authorization
{
    public class PlatformAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            //Common permissions
            var pages = context.GetPermissionOrNull(AppPermissions.Pages);
            if (pages == null)
            {
                pages = context.CreatePermission(AppPermissions.Pages, L("Pages"));
            }

            var systemManage = pages.CreateChildPermission(AppPermissions.Pages_SystemManage, L("SystemManage"));

            var hangfire = pages.CreateChildPermission(AppPermissions.Pages_Hangfire, L("Hangfire"));

            pages.CreateChildPermission(AppPermissions.Pages_Maintenance, L("Maintenance"));

            ////Host permissions
            var tenants = pages.CreateChildPermission(AppPermissions.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, PlatformConsts.LocalizationSourceName);
        }
    }
}
