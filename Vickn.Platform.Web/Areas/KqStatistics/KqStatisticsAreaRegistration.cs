using System.Web.Mvc;

namespace Vickn.Platform.Web.Areas.KqStatistics
{
    public class KqStatisticsAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "KqStatistics";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "KqStatistics_default",
                "KqStatistics/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}