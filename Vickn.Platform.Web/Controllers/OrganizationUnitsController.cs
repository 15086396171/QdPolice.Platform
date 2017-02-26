using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Abp.Application.Services.Dto;
using Vickn.PlatfForm.Utils.Pager;
using Vickn.Platform.Organizations;
using Vickn.Platform.Organizations.Dto;

namespace Vickn.Platform.Web.Controllers
{
    public class OrganizationUnitsController : PlatformControllerBase
    {
        private readonly IOrganizationUnitAppService _organizationUnitAppService;

        public OrganizationUnitsController(IOrganizationUnitAppService organizationUnitAppService)
        {
            _organizationUnitAppService = organizationUnitAppService;
        }

        public async Task<ActionResult> OrganizationUnitTree()
        {
            var result = await _organizationUnitAppService.GetOrganizationUnitDto();
            return PartialView("_OrganizationUnitTree", result);
        }

        // GET: OrganizationUnits
        public async Task<ActionResult> Index(GetOrganizationUnitInput input)
        {
            var result = await _organizationUnitAppService.GetPagedOrganizationUnitAsync(input);
            return View(result.ToPagedList(input));
        }

        public async Task<ActionResult> Create(long? parentId, int? id)
        {
            var result = await _organizationUnitAppService.GetGetOrganizationUnitForEditAsync(new NullableIdDto<long>(id));
            result.ParentId = parentId;
            return View(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create(GetOrganizationUnitForEditOutput output)
        {
            if (!ModelState.IsValid)
            {
                return View(output);
            }
            await _organizationUnitAppService.CreateOrUpdateOrganizationUnit(output);
            return CreateResult;
        }
    }
}