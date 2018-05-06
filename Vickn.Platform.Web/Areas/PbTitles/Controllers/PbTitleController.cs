/*
* 命名空间 :     Vickn.Platform.PbManagement.PbTitles
* 类 名  称 :      PbTitleController 
* 版      本 :      v1.0.0.0
* 文 件  名 :     PbTitleController.cs
* 描      述 :     排班标题表控制器
* 创建时间 :     2018/5/6 14:54:09
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
using Vickn.Platform.PbManagement.PbTitles;
using Vickn.Platform.PbManagement.PbTitles.Authorization;
using Vickn.Platform.PbManagement.PbTitles.Dtos;
using Vickn.Platform.Web.Controllers;

namespace Vickn.Platform.Web.Areas.PbTitles.Controllers
{
    [AbpMvcAuthorize(PbTitleAppPermissions.PbTitle)]
    public class PbTitleController : PlatformControllerBase
    {
        private readonly IPbTitleAppService _pbTitleAppService;

        public PbTitleController(IPbTitleAppService pbTitleAppService)
        {
            _pbTitleAppService = pbTitleAppService;

        }

        public ActionResult Index()
        {
            return View();
        }

        [AbpMvcAuthorize(PbTitleAppPermissions.PbTitle_CreatePbTitle, PbTitleAppPermissions.PbTitle_EditPbTitle)]
        public async Task<ActionResult> Create(int? id)
        {
            var pbTitleDto = await _pbTitleAppService.GetForEditAsync(new NullableIdDto<int>(id));
            return View(pbTitleDto);
        }

        [HttpPost]
        public async Task<ActionResult> Create(PbTitleForEdit pbTitleDto)
        {
            if (!CheckModelState(await _pbTitleAppService.CheckErrorAsync(pbTitleDto)))
            {
                return View(pbTitleDto);
            }
            await _pbTitleAppService.CreateOrUpdateAsync(pbTitleDto);
            return RedirectToAction("Index");
        }

    }
}