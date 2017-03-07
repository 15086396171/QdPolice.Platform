using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Abp.Application.Services.Dto;
using Vickn.PlatfForm.Utils.Pager;
using Vickn.Platform.Authorization.Roles;
using Vickn.Platform.Roles;
using Vickn.Platform.Roles.Dtos;
using Vickn.Platform.Users.Dtos;

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
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Create(int? id)
        {
            var result = await _roleAppService.GetForEditAsync(new NullableIdDto<int>(id));
            return View(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create(GetRoleForEditOutput dto)
        {
            if (!CheckModelState(await _roleAppService.CheckErrorAsync(dto)))
                return View(dto);

            await _roleAppService.CreateOrUpdateAsync(new CreateOrUpdateRoleInput() {RoleEditDto = dto.RoleEditDto});
            //return Content("<script>parent.location.reload()</script>");
            return CreateResult;
        }

        public async Task<ActionResult> Delete(int id)
        {
            var role = await _roleAppService.GetByIdAsync(new EntityDto<int>(id));
            if (role.Name == StaticRoleNames.Tenants.Admin)
                return Json(new { success = false, msg = $"系统角色不能被删除!" });

            await _roleAppService.DeleteAsync(new EntityDto<int>(id));
            return Json(new { success = true });
        }

        public async Task<ActionResult> BatchDelete(List<int> input)
        {
            await _roleAppService.BatchDeleteAsync(input);
            return Json(new { success = true });
        }

        public async Task<ActionResult> SetPermissions(int id)
        {
            var result =await _roleAppService.GetRolePermissionForEditAsync(new EntityDto(id));
            return PartialView("_SetPermissions",result);
        }
    }
}