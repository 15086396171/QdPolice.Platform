using System.Globalization;
using System.Threading;
using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;

namespace Vickn.Platform.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : PlatformControllerBase
    {
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