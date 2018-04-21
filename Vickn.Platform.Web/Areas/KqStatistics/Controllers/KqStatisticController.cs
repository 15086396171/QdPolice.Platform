using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vickn.Platform.Web.Controllers;

namespace Vickn.Platform.Web.Areas.KqStatistics.Controllers
{
    public class KqStatisticController : PlatformControllerBase
    {
        // GET: KqStatistics/KqStatistic
        public ActionResult Index()
        {
            var time = DateTime.Today.DayOfWeek;
           
            return View();
        }
    }
}