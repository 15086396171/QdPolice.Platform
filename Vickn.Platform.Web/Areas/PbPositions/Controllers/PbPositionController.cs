/*
* 命名空间 :     Vickn.Platform.PbManagement.PbPositions
* 类 名  称 :      PbPositionController 
* 版      本 :      v1.0.0.0
* 文 件  名 :     PbPositionController.cs
* 描      述 :     排班岗位控制器
* 创建时间 :     2018/5/6 15:09:44
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
using Vickn.Platform.PbManagement.PbPositions;
using Vickn.Platform.PbManagement.PbPositions.Authorization;
using Vickn.Platform.PbManagement.PbPositions.Dtos;
using Vickn.Platform.Web.Controllers;

namespace Vickn.Platform.Web.Areas.PbPositions.Controllers
{
    [AbpMvcAuthorize(PbPositionAppPermissions.PbPosition)]
    public class PbPositionController : PlatformControllerBase
    {
        private readonly IPbPositionAppService _pbPositionAppService;

        public PbPositionController(IPbPositionAppService pbPositionAppService)
        {
            _pbPositionAppService = pbPositionAppService;

        }

        public ActionResult Index(int pbTitleId)
        {
            ViewBag.pbTitleId = pbTitleId;
            return View();
        }

    }
}