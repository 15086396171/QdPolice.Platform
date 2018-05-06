
using System.Web.Mvc;

namespace Vickn.Platform.Web.Areas.PbTitles
{
    public class PbTitlesAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "PbTitles";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "PbTitles_default",
                "PbTitles/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
