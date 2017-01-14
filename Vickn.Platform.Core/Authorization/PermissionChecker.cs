using Abp.Authorization;
using Vickn.Platform.Authorization.Roles;
using Vickn.Platform.MultiTenancy;
using Vickn.Platform.Users;

namespace Vickn.Platform.Authorization
{
    public class PermissionChecker : PermissionChecker<Tenant, Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
