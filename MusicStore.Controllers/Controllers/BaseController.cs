#region Using Directives

using System.Web.Mvc;

#endregion

namespace MusicStore.Controllers.Controllers
{
    public class BaseController : Controller
    {
        public ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }

            return RedirectToAction("Index", "Home", new { area = string.Empty });
        }
    }
}