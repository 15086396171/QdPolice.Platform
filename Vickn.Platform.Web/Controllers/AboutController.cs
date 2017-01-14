using System.Web.Mvc;

namespace Vickn.Platform.Web.Controllers
{
    public class AboutController : PlatformControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}