
using System.Web.Mvc;

namespace Vickn.Platform.Web.Areas.PrivatePhoneWhites
{
    public class PrivatePhoneWhitesAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "PrivatePhoneWhites";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "PrivatePhoneWhites_default",
                "PrivatePhoneWhites/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
