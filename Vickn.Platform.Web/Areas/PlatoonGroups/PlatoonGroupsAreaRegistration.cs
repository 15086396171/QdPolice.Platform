
using System.Web.Mvc;

namespace Vickn.Platform.Web.Areas.PlatoonGroups
{
    public class PlatoonGroupsAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "PlatoonGroups";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "PlatoonGroups_default",
                "PlatoonGroups/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
