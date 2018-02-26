﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web.Mvc;
using Abp.Application.Services.Dto;
using Abp.Web.Mvc.Authorization;
using Vickn.Platform.Users;
using Vickn.Platform.Users.Authorization;
using Vickn.Platform.Users.Dtos;

namespace Vickn.Platform.Web.Controllers
{
    [AbpMvcAuthorize(UserAppPermissions.User)]
    public class UsersController : PlatformControllerBase
    {
        private readonly IUserAppService _userAppService;

        public UsersController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        public ActionResult Index(long? ouId)
        {
            ViewBag.ouId = ouId;
            return View();
        }

        [AbpMvcAuthorize(UserAppPermissions.User_CreateUser, UserAppPermissions.User_EditUser)]
        public async Task<ActionResult> Create(long? id, long? ouId)
        {
            var result = await _userAppService.GetUserForEditAsync(new NullableIdDto<long>(id));
            if (!result.UserEditDto.Id.HasValue)
                result.OuId = ouId;

            return View(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create(GetUserForEdit dto)
        {
            if (!CheckModelState(await _userAppService.CheckErrorAsync(dto)))
                return View(dto);

            await _userAppService.CreateOrUpdateUserAsync(dto);
            return RedirectToAction("Index", new { ouId = dto.OuId });
        }

        public async Task<ActionResult> ChangeProfilePic()
        {
            return View(await _userAppService.GetMyInfoAsync());
        }


        public async Task<ActionResult> MyInfo()
        {
            return View("_MyInfo", await _userAppService.GetMyInfoAsync());
        }
    }
}