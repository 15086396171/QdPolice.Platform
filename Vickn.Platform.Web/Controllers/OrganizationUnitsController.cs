﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Abp.Authorization.Users;

namespace Vickn.Platform.Web.Controllers
{
    public class OrganizationUnitsController : Controller
    {
        // GET: OrganizationUnits
        public ActionResult Index()
        {
            return View();
        }
    }
}