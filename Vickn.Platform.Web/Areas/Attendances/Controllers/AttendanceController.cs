using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vickn.Platform.Web.Areas.Attendances.Controllers
{
    public class AttendanceController : Controller
    {
        // GET: Attendances/Attendance
        public ActionResult Index()
        {
            return View();
        }
    }
}