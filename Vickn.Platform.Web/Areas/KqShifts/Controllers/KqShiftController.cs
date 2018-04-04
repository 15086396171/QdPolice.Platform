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
        // GET: KqShifts/KqShift
        [AbpMvcAuthorize(KqShiftAppPermissions.KqShift)]
        public ActionResult Index()
        {
            
            return View();
        }
    }
}