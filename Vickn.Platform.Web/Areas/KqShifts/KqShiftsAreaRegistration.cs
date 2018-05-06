using System.Web.Mvc;

namespace Vickn.Platform.Web.Areas.KqShifts
{
    public class KqShiftsAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "KqShifts";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "KqShifts_default",
                "KqShifts/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}