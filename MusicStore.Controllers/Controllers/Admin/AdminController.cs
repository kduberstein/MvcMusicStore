#region Using Directives

using System.Web.Mvc;

#endregion

namespace MusicStore.Controllers.Controllers.Admin
{
    [Authorize]
    public class AdminController : BaseController
    {
        // GET: /Admin
        public ActionResult Index()
        {
            return View();
        }
    }
}