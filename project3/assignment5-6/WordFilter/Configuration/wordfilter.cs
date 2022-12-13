using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace WordFilter.Configuration
{
    public class wordfilter
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes(); // Web API routes
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }

    }
}