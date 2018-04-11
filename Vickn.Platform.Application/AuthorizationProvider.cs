using Abp.Configuration.Startup;
using Vickn.Platform.Announcements.Authorization;
using Vickn.Platform.Attendances.KqMachines.Authorization;
using Vickn.Platform.Attendances.KqShifts.Authorization;
using Vickn.Platform.AuditLogs.Authorization;
using Vickn.Platform.Authorization.Roles.Authorization;
using Vickn.Platform.DataDictionaries.Authorization;
using Vickn.Platform.HandheldTerminals.AppWhiteLists.Authorization;
using Vickn.Platform.HandheldTerminals.Authorization;
using Vickn.Platform.HandheldTerminals.Devices.Authorization;
using Vickn.Platform.OrganizationUnits.Authorization;
using Vickn.Platform.PrivatePhoneWhites.Authorization;
using Vickn.Platform.Users.Authorization;

namespace Vickn.Platform
{
    /// <summary>
    /// 提供系统权限注入
    /// </summary>
    public class AuthorizationProvider
    {
        /// <summary>
        /// 添加所有系统权限
        /// </summary>
        /// <param name="Configuration"></param>
        public void AddAuthorizationProviders(IAbpStartupConfiguration Configuration)
        {
            Configuration.Authorization.Providers.Add<UserAppAuthorizationProvider>();
            Configuration.Authorization.Providers.Add<RoleAppAuthorizationProvider>();
            Configuration.Authorization.Providers.Add<OrganizationUnitAppAuthorizationProvider>();
            Configuration.Authorization.Providers.Add<AuditLogAppAuthorizationProvider>();
            Configuration.Authorization.Providers.Add<DataDictionaryAppAuthorizationProvider>();
            Configuration.Authorization.Providers.Add<DataDictionaryItemAppAuthorizationProvider>();
            Configuration.Authorization.Providers.Add<DeviceAppAuthorizationProvider>();
            Configuration.Authorization.Providers.Add<ForensicsRecordAppAuthorizationProvider>();
            Configuration.Authorization.Providers.Add<AppWhiteListAppAuthorizationProvider>();
            Configuration.Authorization.Providers.Add<PrivatePhoneWhiteAppAuthorizationProvider>();
            Configuration.Authorization.Providers.Add<AnnouncementAppAuthorizationProvider>();
            Configuration.Authorization.Providers.Add<KqShiftAppAuthorizationProvider>();
            Configuration.Authorization.Providers.Add<KqMachineAppAuthorizationProvider>();

        }
    }
}