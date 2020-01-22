using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SecurityLab1_Starter
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "Empty",
               url: "",
               defaults: new { controller = "Home", action = "Index" }
            );

            routes.MapRoute(
                name: "ServerError",
                url: "Error/ServerError",
                defaults: new { controller = "Error", action = "ServerError" }
            );

            routes.MapRoute(
                name: "Home",
                url: "Home/{action}",
                defaults: new { controller = "Home", action = "Index"},
                constraints: new { controller = "Home", action = "Index|About|Contact|GenError" }
            );

            routes.MapRoute(
                name: "Inventory",
                url: "Inventory/{action}",
                defaults: new { controller = "Inventory", action = "Index"},
                constraints: new { controller = "Inventory", action = "Index" }
            );

            routes.MapRoute(
                name: "General Error",
                 url: "error/index",
                defaults: new { controller = "Error", action = "Index" }
            );

            routes.MapRoute(
                name: "CatchAll",
                 url: "{*url}",
                defaults: new { controller = "Error", action = "NotFound"}
            );
        }
    }
}
