/*
* 命名空间 :     Vickn.Platform.PbManagement.Positions
* 类 名  称 :      PositionController 
* 版      本 :      v1.0.0.0
* 文 件  名 :     PositionController.cs
* 描      述 :     岗位控制器
* 创建时间 :     2018/5/6 14:28:50
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
using Vickn.Platform.PbManagement.Positions;
using Vickn.Platform.PbManagement.Positions.Authorization;
using Vickn.Platform.PbManagement.Positions.Dtos;
using Vickn.Platform.Web.Controllers;

namespace Vickn.Platform.Web.Areas.Positions.Controllers
{
	[AbpMvcAuthorize(PositionAppPermissions.Position)]
    public class PositionController : PlatformControllerBase
    {
        private readonly IPositionAppService _positionAppService;

        public PositionController(IPositionAppService positionAppService)
        {
            _positionAppService = positionAppService;
           
        }

        public ActionResult Index()
        {
            return View();
        }

		[AbpMvcAuthorize(PositionAppPermissions.Position_CreatePosition,PositionAppPermissions.Position_EditPosition)]
        public async Task<ActionResult> Create(int? id)
        {
			var positionDto = await _positionAppService.GetForEditAsync(new NullableIdDto<int>(id));
            return View(positionDto);
        }

		[HttpPost]
        public async Task<ActionResult> Create(PositionForEdit positionDto)
        {
            if (!CheckModelState(await _positionAppService.CheckErrorAsync(positionDto)))
            {
			   return View(positionDto);
			 }
            await _positionAppService.CreateOrUpdateAsync(positionDto);
            return RedirectToAction("Index");
        }

    }
}