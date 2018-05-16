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
using System.Web.UI.WebControls;
using Abp.Application.Services.Dto;
using Abp.Web.Mvc.Authorization;
using Vickn.Platform.PbManagement.ChangeWorks;
using Vickn.Platform.PbManagement.ChangeWorks.Authorization;
using Vickn.Platform.PbManagement.ChangeWorks.Dtos;
using Vickn.Platform.PbManagement.PositionPbTimes;
using Vickn.Platform.PbManagement.PositionPbTimes.Dtos;
using Vickn.Platform.Users;
using Vickn.Platform.Web.Controllers;
using Vickn.Platform.Zero.Users.Dtos;

namespace Vickn.Platform.Web.Areas.ChangeWorks.Controllers
{
    [AbpMvcAuthorize(ChangeWorkAppPermissions.ChangeWork)]
    public class ChangeWorkController : PlatformControllerBase
    {
        private readonly IChangeWorkAppService _changeWorkAppService;
        private readonly IPositionPbTimeAppService _positionPbTimeAppService;
        private readonly IUserAppService _userAppService;

        public ChangeWorkController(IChangeWorkAppService changeWorkAppService, IPositionPbTimeAppService positionPbTimeAppService, IUserAppService userAppService)
        {
            _changeWorkAppService = changeWorkAppService;
            _positionPbTimeAppService = positionPbTimeAppService;
            _userAppService = userAppService;
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

                var LeaderList = await _userAppService.GetUserLeaders();

                ViewBag.Leader = new SelectList(LeaderList, "UserName", "UserNameAndPosition");

               
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

            changeWorkDto.ChangeWorkEditDto.Leader = Request["Leader"];
            changeWorkDto.ChangeWorkEditDto.TimeStr = Request["PbTime"]; 
           

            await _changeWorkAppService.CreateOrUpdateAsync(changeWorkDto);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult>  GetTimeUser(DateTime Time)
        {
            var list = await _positionPbTimeAppService.GetUserAllForDutyAsync(
                new GetPositionUserPbTimeListDto {Date = Time});
            return View(list);
        }

        public async Task<ActionResult> ChangeWorkToExamine (long id)
        {

           

            var changeWorkDto = await _changeWorkAppService.GetForEditAsync(new NullableIdDto<long>(id));

          

            return View(changeWorkDto);

          

        }

        public async Task<ActionResult> IsAgreen(long id,string IsAgreeStr)
        {
           
            if (IsAgreeStr == "同意")
            {
                await _changeWorkAppService.LeaderAgreeChangeWorkAsync(new EntityDto<long> { Id = id });
            }
            else
            {
                await _changeWorkAppService.LeaderNotAgreeChangeWorkAsync(new EntityDto<long> { Id = id });
            }

            return RedirectToAction("Index");
        }

    }
}