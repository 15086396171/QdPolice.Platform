using System.Threading.Tasks;
using Abp.Auditing;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Configuration;
using Abp.Localization;
using Abp.Runtime.Session;
using Vickn.Platform.Sessions.Dto;

namespace Vickn.Platform.Sessions
{
    [AbpAuthorize]
    public class SessionAppService : PlatformAppServiceBase, ISessionAppService
    {
        [DisableAuditing]
        public async Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations()
        {
            var output = new GetCurrentLoginInformationsOutput
            {
                User = (await GetCurrentUserAsync()).MapTo<UserLoginInfoDto>()
            };

            if (AbpSession.TenantId.HasValue)
            {
                output.Tenant = (await GetCurrentTenantAsync()).MapTo<TenantLoginInfoDto>();
            }

            return output;
        }

        public async Task SetCurrentCulture(CultureInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(
                      AbpSession.ToUserIdentifier(),
                      LocalizationSettingNames.DefaultLanguage,
                      input.CultureName
                  );
        }
    }
}