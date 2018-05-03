
using System.Web.Mvc;

namespace Vickn.Platform.Web.Areas.SchedulingPosts
{
    public class SchedulingPostsAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "SchedulingPosts";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "SchedulingPosts_default",
                "SchedulingPosts/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
