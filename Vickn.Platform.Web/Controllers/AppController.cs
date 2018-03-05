using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Abp.Authorization;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Vickn.Platform.Authorization;
using Vickn.Platform.Users;

namespace Vickn.Platform.Web.Controllers
{
    [AbpAllowAnonymous]
    public class AppController : PlatformControllerBase
    {
        private readonly LogInManager _logInManager;
        private readonly UserManager _userManager;

        public AppController(LogInManager logInManager, UserManager userManager)
        {
            _logInManager = logInManager;
            _userManager = userManager;
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private async Task SignInAsync(User user, ClaimsIdentity identity = null, bool rememberMe = true)
        {
            if (identity == null)
            {
                identity = await _userManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            }

            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            AuthenticationManager.SignIn(new AuthenticationProperties { IsPersistent = rememberMe }, identity);
        }
        // GET: App
        public async Task<ActionResult> Index(string userName, string password, string urlCode)
        {
            var abpLoginResult = await _logInManager.LoginAsync(userName, password);
            await SignInAsync(abpLoginResult.User, abpLoginResult.Identity);

            switch (urlCode)
            {
                case "anno":
                    return Redirect("/assets/dist/index.html#/documents");
            }
            return View();
        }
    }
}