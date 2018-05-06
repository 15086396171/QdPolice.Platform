
using System.Web.Mvc;

namespace Vickn.Platform.Web.Areas.PbPositions
{
    public class PbPositionsAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "PbPositions";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "PbPositions_default",
                "PbPositions/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
