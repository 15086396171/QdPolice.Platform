using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;
using Vickn.Platform.Authorization;
using Vickn.Platform.MultiTenancy;

namespace Vickn.Platform.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Tenants)]
    public class TenantsController : PlatformControllerBase
    {
        private readonly ITenantAppService _tenantAppService;

        public TenantsController(ITenantAppService tenantAppService)
        {
            _tenantAppService = tenantAppService;
        }

        public ActionResult Index()
        {
            var output = _tenantAppService.GetTenants();
            return View(output);
        }
    }
}