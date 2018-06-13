using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vickn.Platform.Attendences.KqShifts;
using Vickn.Platform.Web.Controllers;

namespace Vickn.Platform.Web.Areas.KqDetails.Controllers
{
    public class KqDetailController : PlatformControllerBase
    {
        private readonly IKqShiftAppService _kqShiftAppService;
        public KqDetailController(IKqShiftAppService kqShiftAppService)
        {
            _kqShiftAppService = kqShiftAppService;
        }

        // GET: KqDetails/KqDetail
        public ActionResult Index()
        {
            DateTime d1 = DateTime.Today;
            DateTime d2 = d1.AddDays(1);

            ViewBag.StartTime = d1.ToString("yyyy-MM-dd");
            ViewBag.EndTime = d2.ToString("yyyy-MM-dd");

            var kqshiftList = _kqShiftAppService.GetAllAsync().Result.ToList();
            ViewBag.KqShiftName = kqshiftList;

            return View();
        }

       
    }
}