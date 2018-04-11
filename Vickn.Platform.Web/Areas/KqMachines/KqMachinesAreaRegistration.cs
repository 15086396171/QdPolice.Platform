using System.Web.Mvc;

namespace Vickn.Platform.Web.Areas.KqMachines
{
    public class KqMachinesAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "KqMachines";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "KqMachines_default",
                "KqMachines/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}