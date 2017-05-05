using System.Web;
using System.Web.Mvc;
using Abp.Configuration;
using Abp.Extensions;
using Abp.IdentityFramework;
using Abp.Localization;
using Abp.Runtime.Session;
using Abp.Timing;
using Abp.UI;
using Abp.Web.Mvc.Controllers;
using Microsoft.AspNet.Identity;
using Vickn.Platform.Dtos;

namespace Vickn.Platform.Web.Controllers
{
    /// <summary>
    /// Derive all Controllers from this class.
    /// </summary>
    public abstract class PlatformControllerBase : AbpController
    {
        protected static readonly ActionResult CreateResult = new ContentResult() { Content = "<script>parent.location.reload()</script>" };

        protected PlatformControllerBase()
        {
            LocalizationSourceName = PlatformConsts.LocalizationSourceName;
        }

        protected void SetCulture(string cultureName)
        {
            Response.Cookies.Add(
                new HttpCookie("Abp.Localization.CultureName", cultureName)
                {
                    Expires = Clock.Now.AddYears(2)
                }
            );

            if (AbpSession.UserId.HasValue)
            {
                SettingManager.ChangeSettingForUser(
                    AbpSession.ToUserIdentifier(),
                    LocalizationSettingNames.DefaultLanguage,
                    cultureName
                );
            }
        }

        protected virtual bool CheckModelState(CustomerModelStateValidationDto customerError)
        {
            if (!ModelState.IsValid)
                return false;
            if (customerError.HasModelError)
            {
                if (!customerError.Key.IsNullOrWhiteSpace())
                    ModelState.AddModelError("", "输入错误");
                ModelState.AddModelError(customerError.Key, customerError.ErrorMessage);
                return false;
            }
            return true;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}