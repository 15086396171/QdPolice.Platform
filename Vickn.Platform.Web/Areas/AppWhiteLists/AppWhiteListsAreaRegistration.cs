
using System.Web.Mvc;

namespace Vickn.Platform.Web.Areas.AppWhiteLists
{
    public class AppWhiteListsAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "AppWhiteLists";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "AppWhiteLists_default",
                "AppWhiteLists/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
