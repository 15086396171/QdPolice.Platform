/*
* 命名空间 :     Vickn.Platform.Announcements
* 类 名  称 :      AnnouncementController 
* 版      本 :      v1.0.0.0
* 文 件  名 :     AnnouncementController.cs
* 描      述 :     通知公告控制器
* 创建时间 :     2018/2/24 13:06:22
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
using Abp.Web.Security.AntiForgery;
using Vickn.Platform.Announcements;
using Vickn.Platform.Announcements.Authorization;
using Vickn.Platform.Announcements.Dtos;
using Vickn.Platform.Web.Controllers;

namespace Vickn.Platform.Web.Areas.Announcements.Controllers
{
	[AbpMvcAuthorize(AnnouncementAppPermissions.Announcement)]
    public class AnnouncementController : PlatformControllerBase
    {
        private readonly IAnnouncementAppService _announcementAppService;

        public AnnouncementController(IAnnouncementAppService announcementAppService)
        {
            _announcementAppService = announcementAppService;
        }

        public ActionResult Index()
        {
            return View();
        }

		[AbpMvcAuthorize(AnnouncementAppPermissions.Announcement_CreateAnnouncement,AnnouncementAppPermissions.Announcement_EditAnnouncement)]
        public async Task<ActionResult> Create(long? id)
        {
			var announcementDto = await _announcementAppService.GetForEditAsync(new NullableIdDto<long>(id));
            return View(announcementDto);
        }

        [HttpPost]
        [ValidateInput(false)]
        public async Task<ActionResult> Create(AnnouncementForEdit announcementDto)
        {
            if (!CheckModelState(await _announcementAppService.CheckErrorAsync(announcementDto)))
            {
                return View(announcementDto);
            }
            await _announcementAppService.CreateOrUpdateAsync(announcementDto);
            return RedirectToAction("Index");
        }
    }
}