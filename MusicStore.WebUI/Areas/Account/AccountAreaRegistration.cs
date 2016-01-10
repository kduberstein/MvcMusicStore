#region Using Directives

using System.Web.Mvc;

#endregion

namespace MusicStore.WebUI.Areas.Account
{
    public class AccountAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get { return "Account"; }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                name: "Account_default",
                url: "Account/{action}/{id}",
                defaults: new { controller = "Account", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "MusicStore.Controllers.Controllers.Account" }
                );
        }
    }
}