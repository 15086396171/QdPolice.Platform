using Abp.Authorization;
using Abp.Authorization.Users;
using Vickn.Platform.Authorization.Roles;
using Vickn.Platform.Users;

namespace Vickn.Platform.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        /// <summary>Constructor.</summary>
        public PermissionChecker(UserManager userManager) : base(userManager)
        {
        }
    }
}