using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OnlineFoodOrdering
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(null, "",
                    new
                    {
                        controller = "FoodItem",
                        action = "FoodItemsList",
                        category = (string)null,
                        page = 1
                    }
                    );
            routes.MapRoute(null, "Page{page}",
                 new
                 {
                     controller = "FoodItem",
                     action = "FoodItemsList",
                     category = (string)null
                 },
                new { page = @"\d+" }
            );

            routes.MapRoute(null,
            "{category}",
            new { controller = "FoodItem", action = "FoodItemsList", page = 1 }
            );

            routes.MapRoute(null,
            "{category}/Page{page}",
            new { controller = "FoodItem", action = "FoodItemsList" },
            new { page = @"\d+" }
            );

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "FoodItem", action = "FoodItemsList", id = UrlParameter.Optional }
            //);
            routes.MapRoute(null, "{controller}/{action}");
        }
    }
}
