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
           
            return View();
        }
    }
}