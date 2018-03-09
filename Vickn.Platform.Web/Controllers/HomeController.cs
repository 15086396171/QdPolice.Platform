using System.Threading;
using System.Web.Mvc;
using Abp.Auditing;
using Abp.Web.Configuration;
using Abp.Web.Mvc.Authorization;
using Vickn.PlatfForm.Utils.Extensions;
using Vickn.Platform.Announcements;

namespace Vickn.Platform.Web.Controllers
{
    [AbpMvcAuthorize]
    [DisableAuditing]
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

        //首页界面
        public ActionResult Welcome()
        {
            //获取公告消息
            

            return View();
        }

        [AllowAnonymous]
        public ActionResult NotFound()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Error()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult NoAuth()
        {
            return View();
        }
    }
}