using System;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using Abp.Authorization;
using Abp.Authorization.Users;
using Abp.UI;
using Abp.Web.Models;
using Abp.WebApi.Controllers;
using Vickn.Platform.Api.Models;
using Vickn.Platform.Authorization;
using Vickn.Platform.MultiTenancy;
using Vickn.Platform.Users;
using Microsoft.Owin.Infrastructure;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Vickn.Platform.HandheldTerminals.Devices;

namespace Vickn.Platform.Api.Controllers
{
    public class AccountController : AbpApiController
    {
        public static OAuthBearerAuthenticationOptions OAuthBearerOptions { get; private set; }

        private readonly LogInManager _logInManager;

        private readonly DeviceManager _deviceManager;

        static AccountController()
        {
            OAuthBearerOptions = new OAuthBearerAuthenticationOptions();
        }

        public AccountController(LogInManager logInManager, DeviceManager deviceManager)
        {
            _logInManager = logInManager;
            _deviceManager = deviceManager;
            LocalizationSourceName = PlatformConsts.LocalizationSourceName;
        }

        [HttpPost]
        public async Task<AjaxResponse> Authenticate(LoginModel loginModel)
        {
            CheckModelState();

            var loginResult = await GetLoginResultAsync(
                loginModel.UsernameOrEmailAddress,
                loginModel.Password,
                loginModel.TenancyName
                );

            if (loginModel.DeviceLoginModel==null)
            {
                return new AjaxResponse(true);
            }

            var deviceLoginResult = await DeviceLogin(loginModel, loginResult);

            loginResult.Identity.AddClaim(new Claim("DeviceId", deviceLoginResult.Device.Id.ToString()));
            var ticket = new AuthenticationTicket(loginResult.Identity, new AuthenticationProperties());

            var currentUtc = new SystemClock().UtcNow;
            ticket.Properties.IssuedUtc = currentUtc;
            ticket.Properties.ExpiresUtc = currentUtc.Add(TimeSpan.FromDays(100));


            return new AjaxResponse(OAuthBearerOptions.AccessTokenFormat.Protect(ticket));
        }

        private async Task<DeviceLoginResult> DeviceLogin(LoginModel loginModel, AbpLoginResult<Tenant, User> loginResult)
        {
            var deviceLoginResult = await _deviceManager.DeviceLoginAsync(loginModel.DeviceLoginModel.Imei, loginModel.DeviceLoginModel.AppVersion, loginModel.DeviceLoginModel.SystemVersion, loginModel.DeviceLoginModel.Status, loginResult.User);
            if (deviceLoginResult.DeviceLogin == DeviceLoginEnum.NotMe)
            {
                throw new UserFriendlyException("登录失败", "设备已绑定其他账号");
            }

            return deviceLoginResult;
        }

        private async Task<AbpLoginResult<Tenant, User>> GetLoginResultAsync(string usernameOrEmailAddress, string password, string tenancyName)
        {
            var loginResult = await _logInManager.LoginAsync(usernameOrEmailAddress, password, tenancyName);

            switch (loginResult.Result)
            {
                case AbpLoginResultType.Success:
                    return loginResult;
                default:
                    throw CreateExceptionForFailedLoginAttempt(loginResult.Result, usernameOrEmailAddress, tenancyName);
            }
        }

        private Exception CreateExceptionForFailedLoginAttempt(AbpLoginResultType result, string usernameOrEmailAddress, string tenancyName)
        {
            switch (result)
            {
                case AbpLoginResultType.Success:
                    return new ApplicationException("Don't call this method with a success result!");
                case AbpLoginResultType.InvalidUserNameOrEmailAddress:
                case AbpLoginResultType.InvalidPassword:
                    return new UserFriendlyException(L("LoginFailed"), L("InvalidUserNameOrPassword"));
                case AbpLoginResultType.InvalidTenancyName:
                    return new UserFriendlyException(L("LoginFailed"), L("ThereIsNoTenantDefinedWithName{0}", tenancyName));
                case AbpLoginResultType.TenantIsNotActive:
                    return new UserFriendlyException(L("LoginFailed"), L("TenantIsNotActive", tenancyName));
                case AbpLoginResultType.UserIsNotActive:
                    return new UserFriendlyException(L("LoginFailed"), L("UserIsNotActiveAndCanNotLogin", usernameOrEmailAddress));
                case AbpLoginResultType.UserEmailIsNotConfirmed:
                    return new UserFriendlyException(L("LoginFailed"), "Your email address is not confirmed. You can not login"); //TODO: localize message
                default: //Can not fall to default actually. But other result types can be added in the future and we may forget to handle it
                    Logger.Warn("Unhandled login fail reason: " + result);
                    return new UserFriendlyException(L("LoginFailed"));
            }
        }

        protected virtual void CheckModelState()
        {
            if (!ModelState.IsValid)
            {
                throw new UserFriendlyException("Invalid request!");
            }
        }
    }
}
