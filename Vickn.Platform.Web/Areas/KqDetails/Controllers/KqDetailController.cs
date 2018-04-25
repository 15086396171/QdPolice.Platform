using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vickn.Platform.Web.Controllers;

namespace Vickn.Platform.Web.Areas.KqDetails.Controllers
{
    public class KqDetailController : PlatformControllerBase
    {
        // GET: KqDetails/KqDetail
        public ActionResult Index()
        {
            DateTime d1 = DateTime.Today;
           
            DateTime d2 = d1.AddDays(1);

            ViewBag.StartTime = d1.ToString("yyyy-MM-dd");
            ViewBag.EndTime = d2.ToString("yyyy-MM-dd");
            return View();
        }

       
    }
}