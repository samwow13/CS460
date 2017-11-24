using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HW8
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //Custom Route to allow for use of Ajax on the Home controller Index page.
            routes.MapRoute(
                name: "Genre",
                url: "Home/GetGenre/{genre}",
                defaults: new {controller = "Home", action = "GetGenre"}
            );

            // standard route built in by MVC
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
