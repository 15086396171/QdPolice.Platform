using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using Abp.Application.Services.Dto;
using Abp.Web.Mvc.Authorization;
using Abp.Web.Security.AntiForgery;
using Vickn.Platform.Authorization;
using Vickn.Platform.Users;
using Vickn.Platform.Users.Dtos;

namespace Vickn.Platform.Web.Controllers
{
    [AbpMvcAuthorize(AppPermissions.Pages_Users)]
    public class UsersController : PlatformControllerBase 
    {
        private readonly IUserAppService _userAppService;

        public UsersController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        public async Task<ActionResult> Index(GetUserInput input)
        {
            var output = await _userAppService.GetPagedUsersAsync(input);
            return View(output);
        }

        public async Task<ActionResult> Create(long? id)
        {
            var result =await _userAppService.GetUserForEditAsync(new NullableIdDto<long>(id));
            return View(result.User);
        }

        [HttpPost]
        [DisableAbpAntiForgeryTokenValidation]
        public async Task<ActionResult> Create(UserEditDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);
            await _userAppService.CreateOrUpdateUserAsync(new CreateOrUpdateUserInput() { UserEditDto = dto });
            //return Content("<script>parent.location.reload()</script>");
            return CreateResult;
        }

        public async Task<ActionResult> Delete(long id)
        {
            await _userAppService.DeleteUserAsync(new EntityDto<long>(id));
            return Json(new {success = true});
        }

        public async Task<ActionResult> BatchDelete(List<long> input)
        {
            await _userAppService.BatchDeleteUserAsync(input);
            return Json(new { success = true });
        } 
    }
}