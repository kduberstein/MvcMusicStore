#region Using Directives

using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Script.Serialization;
using System.Web.Security;
using MusicStore.Controllers.ViewModels.Shared;
using MusicStore.Infrastructure.Authentication.Principal;

#endregion

namespace MusicStore.WebUI
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);

            RouteConfig.RegisterRoutes(RouteTable.Routes);

            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_PostAuthenticateRequest(object sender, EventArgs e)
        {
            var authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];

            if (authCookie == null) { return; }

            var authTicket = FormsAuthentication.Decrypt(authCookie.Value);

            if (authTicket == null) { return; }

            var serializer = new JavaScriptSerializer();

            var serializeModel = serializer.Deserialize<CustomPrincipalViewModel>(authTicket.UserData);

            var newUser = new CustomPrincipal(authTicket.Name)
            {
                Id = serializeModel.Id,
                FirstName = serializeModel.FirstName,
                LastName = serializeModel.LastName,
                AuthorizationRoles = serializeModel.AuthorizationRoles
            };

            HttpContext.Current.User = newUser;
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var exception = Server.GetLastError();

            var httpException = exception as HttpException;

            Response.Clear();

            Server.ClearError();

            var routeData = new RouteData();

            routeData.Values["controller"] = "Error";
            routeData.Values["action"] = "General";
            routeData.Values["exception"] = exception;

            Response.Headers.Add("Content-Type", "text/html");

            Response.StatusCode = 500;

            if (httpException != null)
            {
                Response.StatusCode = httpException.GetHttpCode();

                switch (Response.StatusCode)
                {
                    case 401:
                        routeData.Values["action"] = "Unauthorized";
                        routeData.Values["exception"] = exception;
                        break;
                    case 403:
                        routeData.Values["action"] = "Forbidden";
                        routeData.Values["exception"] = exception;
                        break;
                    case 404:
                        routeData.Values["action"] = "NotFound";
                        routeData.Values["exception"] = exception;
                        break;
                    case 500:
                        routeData.Values["action"] = "InternalServerError";
                        routeData.Values["exception"] = exception;
                        break;
                }
            }

            var factory = ControllerBuilder.Current.GetControllerFactory();

            var requestContext = new RequestContext(new HttpContextWrapper(Context), routeData);

            var errorController = factory.CreateController(requestContext, "Error");

            errorController.Execute(requestContext);
        }
    }
}