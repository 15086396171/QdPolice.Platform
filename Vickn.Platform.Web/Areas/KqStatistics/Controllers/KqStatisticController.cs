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
            DateTime now = DateTime.Today;
            DateTime d1 = new DateTime(now.Year, now.Month, 1);
            DateTime d2 = d1.AddMonths(1).AddDays(-1);

            ViewBag.StartTime = d1.ToString("yyyy-MM-dd");
            ViewBag.EndTime = d2.ToString("yyyy-MM-dd");
            return View();
        }

        public ActionResult Detail(string UserName="",string StartTime="",string EndTime="")
        {
            if (string.IsNullOrEmpty(StartTime) || string.IsNullOrEmpty(EndTime))
            {
                DateTime now = DateTime.Today;
                DateTime d1 = new DateTime(now.Year, now.Month, 1);
                DateTime d2 = d1.AddMonths(1).AddDays(-1);
               
                ViewBag.StartTime = d1.ToString("yyyy-MM-dd");
                ViewBag.EndTime = d2.ToString("yyyy-MM-dd");
            }
            else
            {
               
                ViewBag.StartTime = StartTime;
                ViewBag.EndTime = EndTime;
            }
            ViewBag.UserName = UserName;
            return View();
        }
    }
}