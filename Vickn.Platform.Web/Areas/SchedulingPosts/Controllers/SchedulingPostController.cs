/*
* 命名空间 :     Vickn.Platform.Schedules.SchedulingPosts
* 类 名  称 :      SchedulingPostController 
* 版      本 :      v1.0.0.0
* 文 件  名 :     SchedulingPostController.cs
* 描      述 :     岗位设置控制器
* 创建时间 :     2018/5/3 15:50:27
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
using Vickn.Platform.Schedules.SchedulingPosts;
using Vickn.Platform.Schedules.SchedulingPosts.Authorization;
using Vickn.Platform.Schedules.SchedulingPosts.Dtos;
using Vickn.Platform.Web.Controllers;

namespace Vickn.Platform.Web.Areas.SchedulingPosts.Controllers
{
	[AbpMvcAuthorize(SchedulingPostAppPermissions.SchedulingPost)]
    public class SchedulingPostController : PlatformControllerBase
    {
        private readonly ISchedulingPostAppService _schedulingPostAppService;

        public SchedulingPostController(ISchedulingPostAppService schedulingPostAppService)
        {
            _schedulingPostAppService = schedulingPostAppService;
           
        }

        public ActionResult Index()
        {
            return View();
        }

		[AbpMvcAuthorize(SchedulingPostAppPermissions.SchedulingPost_CreateSchedulingPost,SchedulingPostAppPermissions.SchedulingPost_EditSchedulingPost)]
        public async Task<ActionResult> Create(long? id)
        {
			var schedulingPostDto = await _schedulingPostAppService.GetForEditAsync(new NullableIdDto<long>(id));
            return View(schedulingPostDto);
        }

		[HttpPost]
        public async Task<ActionResult> Create(SchedulingPostForEdit schedulingPostDto)
        {
            if (!CheckModelState(await _schedulingPostAppService.CheckErrorAsync(schedulingPostDto)))
            {
			   return View(schedulingPostDto);
			 }
            await _schedulingPostAppService.CreateOrUpdateAsync(schedulingPostDto);
            return RedirectToAction("Index");
        }

    }
}