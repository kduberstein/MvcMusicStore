#region Using Directives

using System;
using System.Web.Mvc;

#endregion

namespace MusicStore.WebUI.Areas.Cart
{
    public class CartAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get { return "Cart"; }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
               name: "Cart_default",
               url: "Cart/{action}/{id}",
               defaults: new { controller = "Cart", action = "Index", id = UrlParameter.Optional },
               namespaces: new[] { "MusicStore.Controllers.Controllers.Cart" }
               );
        }
    }
}