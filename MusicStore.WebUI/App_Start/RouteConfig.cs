#region Using Directives

using System.Web.Mvc;
using System.Web.Routing;
using MvcSiteMapProvider.Web.Mvc;

#endregion

namespace MusicStore.WebUI
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.IgnoreRoute("{*favicon}", new { favicon = @"(.*/)?favicon.ico(/.*)?" });

            routes.IgnoreRoute("{folder}/{*pathInfo}", new { folder = "Content" });

            XmlSiteMapController.RegisterRoutes(RouteTable.Routes);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "MusicStore.Controllers.Controllers.Home" }
                );
        }
    }
}