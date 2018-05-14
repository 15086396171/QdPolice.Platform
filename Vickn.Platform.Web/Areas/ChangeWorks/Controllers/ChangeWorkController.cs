/*
* 命名空间 :     Vickn.Platform.PbManagement.ChangeWorks
* 类 名  称 :      ChangeWorkController 
* 版      本 :      v1.0.0.0
* 文 件  名 :     ChangeWorkController.cs
* 描      述 :     换班控制器
* 创建时间 :     2018/5/14 10:54:04
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
using Vickn.Platform.PbManagement.ChangeWorks;
using Vickn.Platform.PbManagement.ChangeWorks.Authorization;
using Vickn.Platform.PbManagement.ChangeWorks.Dtos;
using Vickn.Platform.PbManagement.PositionPbTimes;
using Vickn.Platform.PbManagement.PositionPbTimes.Dtos;
using Vickn.Platform.Web.Controllers;

namespace Vickn.Platform.Web.Areas.ChangeWorks.Controllers
{
    [AbpMvcAuthorize(ChangeWorkAppPermissions.ChangeWork)]
    public class ChangeWorkController : PlatformControllerBase
    {
        private readonly IChangeWorkAppService _changeWorkAppService;
        private readonly IPositionPbTimeAppService _positionPbTimeAppService;

        public ChangeWorkController(IChangeWorkAppService changeWorkAppService, IPositionPbTimeAppService positionPbTimeAppService)
        {
            _changeWorkAppService = changeWorkAppService;
            _positionPbTimeAppService = positionPbTimeAppService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [AbpMvcAuthorize(ChangeWorkAppPermissions.ChangeWork_CreateChangeWork, ChangeWorkAppPermissions.ChangeWork_EditChangeWork)]
        public async Task<ActionResult> Create(long? id)
        {
            var changeWorkDto = await _changeWorkAppService.GetForEditAsync(new NullableIdDto<long>(id));
            if (!id.HasValue)
            {
                var positionPbTimeList = await _positionPbTimeAppService.GetAllAsync();
                ViewBag.PbTime = new SelectList(positionPbTimeList, "PbTime", "PbTime");
                var bePositionPbTimeList = await _positionPbTimeAppService.GetAllForUserDutyAsync();
                ViewBag.BePbTime = new SelectList(bePositionPbTimeList, "PbTime", "PbTime");
            }

            return View(changeWorkDto);
        }

        [HttpPost]
        public async Task<ActionResult> Create(ChangeWorkForEdit changeWorkDto)
        {
            if (!CheckModelState(await _changeWorkAppService.CheckErrorAsync(changeWorkDto)))
            {
                return View(changeWorkDto);
            }
            await _changeWorkAppService.CreateOrUpdateAsync(changeWorkDto);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult>  GetTimeUser(DateTime Time)
        {
            var list = await _positionPbTimeAppService.GetUserAllForDutyAsync(
                new GetPositionUserPbTimeListDto {Date = Time});
            return View(list);
        }

    }
}