using System.Linq;
using System.Security.Claims;
using Abp.Extensions;
using Abp.Runtime.Session;

namespace Vickn.PlatfForm.Utils.Extensions
{
    public static class MySessionExtension
    {
        public static long? GetDeviceId(this IAbpSession session)
        {
            var result = GetClaimValue("DeviceId");
            if (result.IsNullOrEmpty())
            {
                return null;
            }
            return long.Parse(result);
        }

        private static string GetClaimValue(string claimType)
        {
            var claimsPrincipal = DefaultPrincipalAccessor.Instance.Principal;

            var claim = claimsPrincipal?.Claims.FirstOrDefault(c => c.Type == claimType);
            if (string.IsNullOrEmpty(claim?.Value))
                return null;

            return claim.Value;
        }
    }
}