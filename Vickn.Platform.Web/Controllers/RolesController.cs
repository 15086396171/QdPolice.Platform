using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Vickn.PlatfForm.Utils.Pager;
using Vickn.Platform.Roles;
using Vickn.Platform.Roles.Dtos;

namespace Vickn.Platform.Web.Controllers
{
    public class RolesController : PlatformControllerBase
    {
        private IRoleAppService _roleAppService;

        public RolesController(IRoleAppService roleAppService)
        {
            _roleAppService = roleAppService;
        }

        // GET: Roles
        public async Task<ActionResult> Index(GetRoleInput input)
        {
            var output = await _roleAppService.GetPagedAsync(input);
            return View(output.ToPagedList(input));
        }
    }
}