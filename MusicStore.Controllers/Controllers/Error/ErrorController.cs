#region Using Directives

using System;
using System.Text;
using System.Web.Mvc;
using MusicStore.Controllers.ViewModels.Error;
using MusicStore.Infrastructure.Logging;

#endregion

namespace MusicStore.Controllers.Controllers.Error
{
    public class ErrorController : BaseController
    {
        private readonly ILocalLogger _logger;

        public ErrorController(ILocalLogger logger)
        {
            _logger = logger;
        }

        // GET: /Error/General
        public ActionResult General()
        {
            return View(ProcessError());
        }

        // 401 Error
        // GET: /Error/Unauthorized
        public ActionResult Unauthorized()
        {
            return View(ProcessError());
        }

        // 403 Error
        // GET: /Error/Forbidden
        public ActionResult Forbidden()
        {
            return View(ProcessError());
        }

        // 404 Error
        // GET: /Error/NotFound
        public ActionResult NotFound()
        {
            return View(ProcessError());
        }

        // 500 Error
        // GET: /Error/InternalServerError
        public ActionResult InternalServerError()
        {
            return View(ProcessError());
        }

        private ErrorViewModel ProcessError()
        {
            var model = new ErrorViewModel();

            if (System.Web.HttpContext.Current.AllErrors == null) { return model; }

            var ex = System.Web.HttpContext.Current.AllErrors[0];

            var msg = GetErrorMessage(ex, false);

            _logger.LogError(msg, ex);

            model.Message = msg;

            return model;
        }

        private static string GetErrorMessage(Exception ex, bool includeStackTrace)
        {
            var msg = new StringBuilder();

            BuildErrorMessage(ex, ref msg);

            if (!includeStackTrace) { return msg.ToString(); }

            msg.Append("\n").Append(ex.StackTrace);

            return msg.ToString();
        }

        private static void BuildErrorMessage(Exception ex, ref StringBuilder msg)
        {
            while (true)
            {
                if (ex != null)
                {
                    msg.Append(ex.Message).Append("\n");

                    if (ex.InnerException != null)
                    {
                        ex = ex.InnerException;

                        continue;
                    }
                }

                break;
            }
        }
    }
}