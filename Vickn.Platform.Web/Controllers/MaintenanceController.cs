using System.Web.Mvc;
using Abp.Auditing;
using Abp.Web.Mvc.Authorization;
using Vickn.Platform.Authorization;
using Vickn.Platform.MainTenance.Caching;
using Vickn.Platform.MainTenance.Logging;
using Vickn.Platform.Web.Models.Maintenance;

namespace Vickn.Platform.Web.Controllers
{
    [AbpMvcAuthorize(AppPermissions.Pages_Maintenance)]
    [DisableAuditing]
    public class MaintenanceController : PlatformControllerBase
    {
        private readonly ICachingAppService _cachingAppService;


        public MaintenanceController(ICachingAppService cachingAppService)
        {
            _cachingAppService = cachingAppService;
        }

        public ActionResult Index()
        {
            var model = new MaintenanceViewModel
            {
                Caches = _cachingAppService.GetAllCaches().Items
            };
            return View(model);
        }
    }
}