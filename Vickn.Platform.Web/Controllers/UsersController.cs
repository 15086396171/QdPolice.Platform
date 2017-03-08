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

        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Create(long? id)
        {
            var result = await _userAppService.GetUserForEditAsync(new NullableIdDto<long>(id));
            return View(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create(GetUserForEdit dto)
        {
            if (!CheckModelState(await _userAppService.CheckErrorAsync(dto)))
                return View(dto);

            await _userAppService.CreateOrUpdateUserAsync(dto);
            //return Content("<script>parent.location.reload()</script>");
            return CreateResult;
        }
    }
}