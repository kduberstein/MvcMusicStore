#region Using Directives

using System.Web.Mvc;

#endregion

namespace MusicStore.WebUI.Areas.Checkout
{
    public class CheckoutAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get { return "Checkout"; }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                name: "Checkout_default",
                url: "Checkout/{action}/{id}",
                defaults: new { controller = "Checkout", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "MusicStore.Controllers.Controllers.Checkout" }
                );
        }
    }
}