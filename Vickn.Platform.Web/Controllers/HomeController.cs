using System.Threading;
using System.Web.Mvc;
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
            return View();
        }

        public ActionResult Welcome()
        {
            return View();
        }
        public string GetCultureName()
        {
            return Thread.CurrentThread.CurrentUICulture.DisplayName +"\r\n"+ Thread.CurrentThread.CurrentUICulture.Name;
            //Thread.CurrentThread.CurrentUICulture = new CultureInfo();
        }
    }
}