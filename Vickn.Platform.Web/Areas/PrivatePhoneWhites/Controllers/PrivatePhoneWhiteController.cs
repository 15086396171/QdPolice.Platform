/*
* 命名空间 :     Vickn.Platform.PrivatePhoneWhites
* 类 名  称 :      PrivatePhoneWhiteController 
* 版      本 :      v1.0.0.0
* 文 件  名 :     PrivatePhoneWhiteController.cs
* 描      述 :     个人白名单控制器
* 创建时间 :     2018/2/23 14:23:58
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using Abp.Application.Services.Dto;
using Abp.Web.Mvc.Authorization;
using Vickn.Platform.PrivatePhoneWhites;
using Vickn.Platform.PrivatePhoneWhites.Authorization;
using Vickn.Platform.PrivatePhoneWhites.Dtos;
using Vickn.Platform.Web.Controllers;

namespace Vickn.Platform.Web.Areas.PrivatePhoneWhites.Controllers
{
    [AbpMvcAuthorize(PrivatePhoneWhiteAppPermissions.PrivatePhoneWhite)]
    public class PrivatePhoneWhiteController : PlatformControllerBase
    {
        private readonly IPrivatePhoneWhiteAppService _privatePhoneWhiteAppService;

        public PrivatePhoneWhiteController(IPrivatePhoneWhiteAppService privatePhoneWhiteAppService)
        {
            _privatePhoneWhiteAppService = privatePhoneWhiteAppService;

        }

        public ActionResult Index(long userId)
        {
            ViewBag.userId = userId;
            return View();
        }

        [AbpMvcAuthorize(PrivatePhoneWhiteAppPermissions.PrivatePhoneWhite_CreatePrivatePhoneWhite, PrivatePhoneWhiteAppPermissions.PrivatePhoneWhite_EditPrivatePhoneWhite)]
        public async Task<ActionResult> Create(long? id, long? userId)
        {
            var privatePhoneWhiteDto = await _privatePhoneWhiteAppService.GetForEditAsync(new NullableIdDto<long>(id));

            if (!id.HasValue)
                privatePhoneWhiteDto.PrivatePhoneWhiteEditDto.UserId = userId.Value;

            return View(privatePhoneWhiteDto);
        }

        [HttpPost]
        public async Task<ActionResult> Create(PrivatePhoneWhiteForEdit privatePhoneWhiteDto)
        {
            if (!CheckModelState(await _privatePhoneWhiteAppService.CheckErrorAsync(privatePhoneWhiteDto)))
            {
                return View(privatePhoneWhiteDto);
            }
            await _privatePhoneWhiteAppService.CreateOrUpdateAsync(privatePhoneWhiteDto);
            return RedirectToAction("Index", new { userId = privatePhoneWhiteDto.PrivatePhoneWhiteEditDto.UserId });
        }

    }
}