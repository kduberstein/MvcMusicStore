#region Using Directives

using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;
using MusicStore.Controllers.Mapping;
using MusicStore.Controllers.ViewModels.Account;
using MusicStore.Controllers.ViewModels.Shared;
using MusicStore.Infrastructure.Authentication;
using MusicStore.Services.Interfaces;
using MusicStore.Services.Messaging.CustomerService;
using MusicStore.Services.Messaging.MembershipService;

#endregion

namespace MusicStore.Controllers.Controllers.Account
{
    [Authorize]
    public class AccountController : BaseController
    {
        private readonly ICustomerService _customerService;
        private readonly IFormsAuthentication _formsAuthentication;
        private readonly IMembershipService _membershipService;

        public AccountController(ICustomerService customerService, IFormsAuthentication formsAuthentication,
            IMembershipService membershipService)
        {
            _customerService = customerService;
            _formsAuthentication = formsAuthentication;
            _membershipService = membershipService;
        }

        // GET: /Account
        public ActionResult Index()
        {
            var customerId = System.Web.HttpContext.Current.User.Identity.Name;

            var response = _customerService.GetCustomer(new GetCustomerRequest { Id = new Guid(customerId) });

            var model = new IndexAccountViewModel { Customer = response.Customer };

            return View(model);
        }

        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            string returnUrl = null;

            if (Request.UrlReferrer != null)
            {
                returnUrl = HttpUtility.ParseQueryString(Request.UrlReferrer.Query)["ReturnUrl"];
            }

            var model = new RegisterAccountViewModel
            {
                ReturnUrl = returnUrl,
                HasIssues = false,
                ErrorMessage = string.Empty
            };

            return View(model);
        }

        // POST: /Account/Register
        [HttpPost, AllowAnonymous, ValidateAntiForgeryToken]
        public ActionResult Register(RegisterAccountViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid) { return View(model); }

            var request = model.ConvertToRegisterUserLoginRequest();

            var response = _membershipService.RegisterUserLogin(request);

            if (response.UserLogin.IsAuthenticated)
            {
                var authCookie = SetRegistrationCookie(response);

                Response.Cookies.Add(authCookie);

                return RedirectToLocal(returnUrl);
            }

            model.HasIssues = true;

            model.ErrorMessage = !string.IsNullOrEmpty(response.ErrorMessage)
                ? response.ErrorMessage
                : "Sorry we could not authenticate you.  Please try again.";

            return View(model);
        }

        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;

            var model = new LoginAccountViewModel
            {
                HasIssues = false,
                ErrorMessage = string.Empty
            };

            return View(model);
        }

        // POST: /Account/Login
        [HttpPost, AllowAnonymous, ValidateAntiForgeryToken]
        public ActionResult Login(LoginAccountViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid) { return View(model); }

            var response = _membershipService.LoginUser(model.ConvertToLoginUserRequest());

            if (!response.HasIssues && response.UserLogin.IsAuthenticated)
            {
                var authCookie = SetLoginCookie(response);

                Response.Cookies.Add(authCookie);

                return RedirectToLocal(returnUrl);
            }

            model.HasIssues = true;

            model.ErrorMessage = !string.IsNullOrEmpty(response.ErrorMessage)
                ? response.ErrorMessage
                : "Sorry we could not authenticate you.  Please try again.";

            return View(model);
        }

        // POST: /Account/SignOut
        public ActionResult SignOut()
        {
            _formsAuthentication.SignOut();

            return RedirectToAction("Index", "Home", new { area = string.Empty });
        }

        private HttpCookie SetRegistrationCookie(RegisterUserResponse response)
        {
            var customPrincipalViewModel = new CustomPrincipalViewModel
            {
                Id = response.UserLogin.Id,
                FirstName = response.FirstName,
                LastName = response.LastName,
                AuthorizationRoles = response.AuthorizationRoles
            };

            var userData = new JavaScriptSerializer().Serialize(customPrincipalViewModel);

            var authTicket = new FormsAuthenticationTicket(1, response.CustomerId.ToString(), DateTime.Now, DateTime.Now.AddMinutes(60),
                false, userData);

            var encryptedTicket = _formsAuthentication.Encrypt(authTicket);

            return new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket) { HttpOnly = true, Expires = authTicket.Expiration };
        }

        private HttpCookie SetLoginCookie(LoginUserResponse response)
        {
            var customPrincipalViewModel = new CustomPrincipalViewModel
            {
                Id = response.UserLogin.Id,
                FirstName = response.FirstName,
                LastName = response.LastName
            };

            var userData = new JavaScriptSerializer().Serialize(customPrincipalViewModel);

            var authTicket = new FormsAuthenticationTicket(1, response.CustomerId, DateTime.Now, DateTime.Now.AddMinutes(60), false,
                userData);

            var encryptedTicket = _formsAuthentication.Encrypt(authTicket);

            return new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket) { HttpOnly = true, Expires = authTicket.Expiration };
        }
    }
}