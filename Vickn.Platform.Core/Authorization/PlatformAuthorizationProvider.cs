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

            pages.CreateChildPermission(AppPermissions.Pages_SystemManage, L("SystemManage"));

            pages.CreateChildPermission(AppPermissions.Pages_Hangfire, L("Hangfire"));

            pages.CreateChildPermission(AppPermissions.Pages_Maintenance, L("Maintenance"));

          

            pages.CreateChildPermission(AppPermissions.Pages_Api, L("Api"));

            ////Host permissions
            var tenants = pages.CreateChildPermission(AppPermissions.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, PlatformConsts.LocalizationSourceName);
        }
    }
}
