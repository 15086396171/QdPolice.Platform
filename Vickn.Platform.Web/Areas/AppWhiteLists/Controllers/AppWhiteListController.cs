/*
* 命名空间 :     Vickn.Platform.HandheldTerminals.AppWhiteLists
* 类 名  称 :      AppWhiteListController 
* 版      本 :      v1.0.0.0
* 文 件  名 :     AppWhiteListController.cs
* 描      述 :     应用白名单控制器
* 创建时间 :     2018/2/5 15:17:14
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
using Vickn.Platform.HandheldTerminals.AppWhiteLists;
using Vickn.Platform.HandheldTerminals.AppWhiteLists.Authorization;
using Vickn.Platform.HandheldTerminals.AppWhiteLists.Dtos;
using Vickn.Platform.Web.Controllers;

namespace Vickn.Platform.Web.Areas.AppWhiteLists.Controllers
{
	[AbpMvcAuthorize(AppWhiteListAppPermissions.AppWhiteList)]
    public class AppWhiteListController : PlatformControllerBase
    {
        private readonly IAppWhiteListAppService _appWhiteListAppService;

        public AppWhiteListController(IAppWhiteListAppService appWhiteListAppService)
        {
            _appWhiteListAppService = appWhiteListAppService;
           
        }

        public ActionResult Index()
        {
            return View();
        }

		[AbpMvcAuthorize(AppWhiteListAppPermissions.AppWhiteList_CreateAppWhiteList,AppWhiteListAppPermissions.AppWhiteList_EditAppWhiteList)]
        public async Task<ActionResult> Create(long? id)
        {
			var appWhiteListDto = await _appWhiteListAppService.GetForEditAsync(new NullableIdDto<long>(id));
            return View(appWhiteListDto);
        }

		[HttpPost]
        public async Task<ActionResult> Create(AppWhiteListForEdit appWhiteListDto)
        {
            if (!CheckModelState(await _appWhiteListAppService.CheckErrorAsync(appWhiteListDto)))
            {
			   return View(appWhiteListDto);
			 }
            await _appWhiteListAppService.CreateOrUpdateAsync(appWhiteListDto);
            return RedirectToAction("Index");
        }

    }
}