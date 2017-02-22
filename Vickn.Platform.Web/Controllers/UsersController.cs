using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web.Mvc;
using Abp.Application.Services.Dto;
using Abp.Web.Mvc.Authorization;
using Abp.Web.Security.AntiForgery;
using Vickn.PlatfForm.Utils;
using Vickn.PlatfForm.Utils.Pager;
using Vickn.Platform.Authorization;
using Vickn.Platform.Users;
using Vickn.Platform.Users.Dtos;

namespace Vickn.Platform.Web.Controllers
{
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

            return View(output.ToPagedList(input));
        }

        public async Task<ActionResult> Create(long? id)
        {
            var result = await _userAppService.GetUserForEditAsync(new NullableIdDto<long>(id));
            return View(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create(GetUserForEditOutput dto)
        {
            if (!CheckModelState(await _userAppService.CheckErrorAsync(dto.User)))
                return View(dto);

            await _userAppService.CreateOrUpdateUserAsync(new CreateOrUpdateUserInput { UserEditDto = dto.User,UserRoleDtos = dto.UserRoleDtos});
            //return Content("<script>parent.location.reload()</script>");
            return CreateResult;
        }

        public async Task<ActionResult> Delete(long id)
        {
            var user = await _userAppService.GetUserByIdAsync(new EntityDto<long>(id));
            if (user.UserName == PlatformConsts.UserConst.DefaultAdminUserName)
                return Json(new {success = false, msg = $"系统管理员不能被删除!"});

            await _userAppService.DeleteUserAsync(new EntityDto<long>(id));
            return Json(new { success = true });
        }

        public async Task<ActionResult> BatchDelete(List<long> input)
        {
            await _userAppService.BatchDeleteUserAsync(input);
            return Json(new { success = true });
        }

    }
}