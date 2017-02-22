using System.Globalization;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Abp.Configuration;
using Abp.Localization;
using Abp.Runtime.Session;
using Abp.Timing;
using Abp.Web.Configuration;
using Abp.Web.Mvc.Authorization;

namespace Vickn.Platform.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : PlatformControllerBase
    {
        private readonly IAbpWebLocalizationConfiguration _webLocalizationConfiguration;
        public HomeController(IAbpWebLocalizationConfiguration webLocalizationConfiguration)
        {
            _webLocalizationConfiguration = webLocalizationConfiguration;
        }
        public ActionResult Index()
        {
            SetCulture("zh-CN");
            return View();
        }

        public ActionResult Welcome()
        {
            return View();
        }

        private void SetCulture(string cultureName)
        {
            Response.Cookies.Add(
                new HttpCookie(_webLocalizationConfiguration.CookieName, cultureName)
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

        public string GetCultureName()
        {
            return Thread.CurrentThread.CurrentUICulture.DisplayName +"\r\n"+ Thread.CurrentThread.CurrentUICulture.Name;
            //Thread.CurrentThread.CurrentUICulture = new CultureInfo();
        }
    }
}