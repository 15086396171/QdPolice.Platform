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
                pages = context.CreatePermission(AppPermissions.Pages, L("页面"));
            }

            var systemManage = pages.CreateChildPermission(AppPermissions.Pages_SystemManage, L("SystemManage"));

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
