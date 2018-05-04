/*
* 命名空间 :     Vickn.Platform.Schedules.PlatoonGroups
* 类 名  称 :      PlatoonGroupController 
* 版      本 :      v1.0.0.0
* 文 件  名 :     PlatoonGroupController.cs
* 描      述 :     排班组控制器
* 创建时间 :     2018/5/4 15:42:37
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
using Vickn.Platform.Schedules.PlatoonGroups;
using Vickn.Platform.Schedules.PlatoonGroups.Authorization;
using Vickn.Platform.Schedules.PlatoonGroups.Dtos;
using Vickn.Platform.Web.Controllers;

namespace Vickn.Platform.Web.Areas.PlatoonGroups.Controllers
{
	[AbpMvcAuthorize(PlatoonGroupAppPermissions.PlatoonGroup)]
    public class PlatoonGroupController : PlatformControllerBase
    {
        private readonly IPlatoonGroupAppService _platoonGroupAppService;

        public PlatoonGroupController(IPlatoonGroupAppService platoonGroupAppService)
        {
            _platoonGroupAppService = platoonGroupAppService;
           
        }

        public ActionResult Index()
        {
            return View();
        }

		[AbpMvcAuthorize(PlatoonGroupAppPermissions.PlatoonGroup_CreatePlatoonGroup,PlatoonGroupAppPermissions.PlatoonGroup_EditPlatoonGroup)]
        public async Task<ActionResult> Create(long? id)
        {
			var platoonGroupDto = await _platoonGroupAppService.GetForEditAsync(new NullableIdDto<long>(id));
            return View(platoonGroupDto);
        }

		[HttpPost]
        public async Task<ActionResult> Create(PlatoonGroupForEdit platoonGroupDto)
        {
            if (!CheckModelState(await _platoonGroupAppService.CheckErrorAsync(platoonGroupDto)))
            {
			   return View(platoonGroupDto);
			 }
            await _platoonGroupAppService.CreateOrUpdateAsync(platoonGroupDto);
            return RedirectToAction("Index");
        }

    }
}