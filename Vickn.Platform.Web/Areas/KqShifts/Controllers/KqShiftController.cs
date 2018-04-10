using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using Abp.Application.Services.Dto;
using Abp.Web.Mvc.Authorization;
using Abp.Web.Security.AntiForgery;
using Vickn.Platform.Attendences.KqShifts;
using Vickn.Platform.Attendences.KqShifts.Dtos;
using Vickn.Platform.Attendances.KqShifts.Authorization;
using Vickn.Platform.Web.Controllers;

namespace Vickn.Platform.Web.Areas.KqShifts.Controllers
{
    public class KqShiftController : PlatformControllerBase
    {
        private readonly  IKqShiftAppService _kqShiftAppService;

        public KqShiftController(IKqShiftAppService kqShiftAppService)
        {
            _kqShiftAppService = kqShiftAppService;
        }

        // GET: KqShifts/KqShift
        [AbpMvcAuthorize(KqShiftAppPermissions.KqShift)]
        public ActionResult Index()
        {
 
            return View();
        }

        [AbpMvcAuthorize(KqShiftAppPermissions.KqShift_CreateKqShift, KqShiftAppPermissions.KqShift_EditKqShift)]
        public async Task<ActionResult> Create(long? id)
        {
            var kqshiftDto = await _kqShiftAppService.GetForEditAsync(new NullableIdDto<long>(id));
            
            return View(kqshiftDto);


        }

        [HttpPost]
        [ValidateInput(false)]
        public async Task<ActionResult> Create(KqShiftForEidt kqshiftDto)
        {
           
            await _kqShiftAppService.CreateOrUpdateAsync(kqshiftDto);
            return RedirectToAction("Index");

           
        }
    }
}