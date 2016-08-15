using System.Web.Mvc;

namespace DuongThaiKiet.Areas.Blog
{
    public class BlogAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Blog";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Blog_default",
                "Blog/{controller}/{action}/{id}",
                new { controller ="BlogEntries" , action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}