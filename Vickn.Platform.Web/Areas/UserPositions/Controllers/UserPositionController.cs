/*
* 命名空间 :     Vickn.Platform.Zero.UserPositions
* 类 名  称 :      UserPositionController 
* 版      本 :      v1.0.0.0
* 文 件  名 :     UserPositionController.cs
* 描      述 :     职位信息控制器
* 创建时间 :     2018/5/16 10:28:56
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
using Vickn.Platform.Zero.UserPositions;
using Vickn.Platform.Zero.UserPositions.Authorization;
using Vickn.Platform.Zero.UserPositions.Dtos;
using Vickn.Platform.Web.Controllers;

namespace Vickn.Platform.Web.Areas.UserPositions.Controllers
{
	[AbpMvcAuthorize(UserPositionAppPermissions.UserPosition)]
    public class UserPositionController : PlatformControllerBase
    {
        private readonly IUserPositionAppService _userPositionAppService;

        public UserPositionController(IUserPositionAppService userPositionAppService)
        {
            _userPositionAppService = userPositionAppService;
           
        }

        public ActionResult Index()
        {
            return View();
        }

		[AbpMvcAuthorize(UserPositionAppPermissions.UserPosition_CreateUserPosition,UserPositionAppPermissions.UserPosition_EditUserPosition)]
        public async Task<ActionResult> Create(long? id)
        {
			var userPositionDto = await _userPositionAppService.GetForEditAsync(new NullableIdDto<long>(id));
            return View(userPositionDto);
        }

		[HttpPost]
        public async Task<ActionResult> Create(UserPositionForEdit userPositionDto)
        {
            if (!CheckModelState(await _userPositionAppService.CheckErrorAsync(userPositionDto)))
            {
			   return View(userPositionDto);
			 }
            await _userPositionAppService.CreateOrUpdateAsync(userPositionDto);
            return RedirectToAction("Index");
        }

    }
}