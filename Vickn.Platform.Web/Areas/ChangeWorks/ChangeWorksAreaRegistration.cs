
using System.Web.Mvc;

namespace Vickn.Platform.Web.Areas.ChangeWorks
{
    public class ChangeWorksAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "ChangeWorks";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "ChangeWorks_default",
                "ChangeWorks/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
