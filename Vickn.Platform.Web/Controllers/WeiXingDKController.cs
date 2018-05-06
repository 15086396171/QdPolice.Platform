using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vickn.Platform.Users;

namespace Vickn.Platform.Web.Controllers
{
    public class WeiXingDKController : Controller
    {
       

        // GET: WeiXingDK
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult GPSposition()
        {
            return View();
        }
    }
}