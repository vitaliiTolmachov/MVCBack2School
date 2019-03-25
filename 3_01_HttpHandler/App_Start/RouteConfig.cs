using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using _3_01_HttpHandler.Handlers;

namespace _3_01_HttpHandler
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("home/about");
            //routes.Add(new Route("home/about", routeHandler: new HandlerProvider()));

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }

    //public class HandlerProvider : IRouteHandler
    //{
    //    public IHttpHandler GetHttpHandler(RequestContext requestContext)
    //    {
    //        return new MyHttpHandler();
    //    }
    //}
}