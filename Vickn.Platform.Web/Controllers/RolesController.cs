using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Abp.Application.Services.Dto;
using Vickn.PlatfForm.Utils.Pager;
using Vickn.Platform.Authorization.Roles;
using Vickn.Platform.DataDictionaries;
using Vickn.Platform.DataDictionaries.EntityMapper;
using Vickn.Platform.Roles;
using Vickn.Platform.Roles.Dtos;
using Vickn.Platform.Users.Dtos;

namespace Vickn.Platform.Web.Controllers
{
    public class RolesController : PlatformControllerBase
    {
        private IRoleAppService _roleAppService;
        private DataDictionaryManager _dataDictionaryManager;

        public RolesController(IRoleAppService roleAppService, DataDictionaryManager dataDictionaryManager)
        {
            _roleAppService = roleAppService;
            _dataDictionaryManager = dataDictionaryManager;
        }

        // GET: Roles
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Create(int? id)
        {
            var result = await _roleAppService.GetForEditAsync(new NullableIdDto<int>(id));
            await SetWeightDropdownList(result);
            return View(result);
        }

        private async Task SetWeightDropdownList(GetRoleForEditOutput result)
        {
            var weightItem = await _dataDictionaryManager.GetDataDictionaryAsync(StaticDictionaryNames.Role_Weight);
            result.WeightList = weightItem.DataDictionaryItems.Select(p => new SelectListItem()
            {
                Text = p.DisplayName,
                Value = p.Value
            }).ToList();
        }

        [HttpPost]
        public async Task<ActionResult> Create(GetRoleForEditOutput dto)
        {
            if (!CheckModelState(await _roleAppService.CheckErrorAsync(dto)))
            {
                await SetWeightDropdownList(dto);
                return View(dto);
            }

            await _roleAppService.CreateOrUpdateAsync(new CreateOrUpdateRoleInput() { RoleEditDto = dto.RoleEditDto });
            //return Content("<script>parent.location.reload()</script>");
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> SetPermissions(int id)
        {
            var result = await _roleAppService.GetRolePermissionForEditAsync(new EntityDto(id));
            return PartialView("_SetPermissions", result);
        }
    }
}