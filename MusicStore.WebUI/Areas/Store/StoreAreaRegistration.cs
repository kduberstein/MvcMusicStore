#region Using Directives

using System.Web.Mvc;

#endregion

namespace MusicStore.WebUI.Areas.Store
{
    public class StoreAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get { return "Store"; }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                name: "Store_browse",
                url: "Store/Browse/{genre}",
                defaults: new { controller = "Store", action = "Browse" },
                namespaces: new[] { "MusicStore.Controllers.Controllers.Store" }
                );

            context.MapRoute(
                name: "Store_detail",
                url: "Store/Detail/{id}",
                defaults: new { controller = "Store", action = "Detail" },
                namespaces: new[] { "MusicStore.Controllers.Controllers.Store" }
                );

            context.MapRoute(
                name: "Store_default",
                url: "Store/{action}/{id}",
                defaults: new { controller = "Store", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "MusicStore.Controllers.Controllers.Store" }
                );
        }
    }
}