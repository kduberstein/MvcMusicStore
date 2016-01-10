#region Using Directives

using System.Web.Mvc;

#endregion

namespace MusicStore.Controllers.Controllers.Home
{
    public class HomeController : BaseController
    {
        // GET: /Home
        public ActionResult Index()
        {
            return View();
        }

        // GET: /About
        public ActionResult About()
        {
            return View();
        }
    }
}