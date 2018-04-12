using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vickn.Platform.Web.Controllers;

namespace Vickn.Platform.Web.Areas.KqMachines.Controllers
{
    public class KqMachineController : PlatformControllerBase
    {
        // GET: KqMachines/KqMachine
        public ActionResult Index()
        {
            return View();
        }
    }
}