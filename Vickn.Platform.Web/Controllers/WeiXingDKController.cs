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
        private readonly IRepository<User, long> _Usersrepository;

        public WeiXingDKController(IRepository<User, long> Usersrepository)
        {
            _Usersrepository = Usersrepository;
        }

        // GET: WeiXingDK
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult IsLoginSucces(string username = "",string password="")
        {
            var entity = _Usersrepository.FirstOrDefault(p => p.UserName == username && p.Password == password);

            /// api / Account
            return View();
        }
    }
}