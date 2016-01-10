#region Using Directives

using System;
using System.Linq;
using System.Web.Mvc;
using MusicStore.Controllers.DataKeys;
using MusicStore.Controllers.Mapping;
using MusicStore.Controllers.ViewModels.Checkout;
using MusicStore.Infrastructure.Authentication;
using MusicStore.Infrastructure.CookieStorage;
using MusicStore.Services.Interfaces;
using MusicStore.Services.Messaging.CustomerService;
using MusicStore.Services.Messaging.OrderService;

#endregion

namespace MusicStore.Controllers.Controllers.Checkout
{
    [Authorize]
    public class CheckoutController : BaseController
    {
        private readonly ICookieStorageService _cookieStorageService;
        private readonly ICustomerService _customerService;
        private readonly IFormsAuthentication _formsAuthentication;
        private readonly IMembershipService _membershipService;
        private readonly IOrderService _orderService;

        public CheckoutController(ICookieStorageService cookieStorageService, ICustomerService customerService,
            IFormsAuthentication formsAuthentication, IMembershipService membershipService, IOrderService orderService)
        {
            _cookieStorageService = cookieStorageService;
            _customerService = customerService;
            _formsAuthentication = formsAuthentication;
            _membershipService = membershipService;
            _orderService = orderService;
        }

        // GET: /Checkout/AddressAndPayment
        public ActionResult AddressAndPayment()
        {
            var customerId = _formsAuthentication.GetAuthenticationToken();

            var response = _customerService.GetCustomer(new GetCustomerRequest { Id = new Guid(customerId) });

            var model = response.ConvertToAddressAndPaymentCheckoutViewModel();

            model.StatesLookupList = _membershipService.GetAllStates().States.OrderBy(s => s.Abbr);

            return View(model);
        }

        // POST: /Checkout/AddressAndPayment
        [HttpPost]
        public ActionResult AddressAndPayment(AddressAndPaymentCheckoutViewModel model)
        {
            if (ModelState.IsValid)
            {
                var request = model.ConvertToCreateOrderRequest();

                request.CartId = GetCartId();

                var response = _orderService.CreateOrder(request);

                _cookieStorageService.Save(CookieDataKeys.CartItems.ToString(), "0", DateTime.Now.AddDays(1));
                _cookieStorageService.Save(CookieDataKeys.CartTotal.ToString(), "0", DateTime.Now.AddDays(1));

                return RedirectToAction("Complete", new { id = response.Order.Id });
            }

            model.StatesLookupList = _membershipService.GetAllStates().States.OrderBy(s => s.Abbr);

            return View(model);
        }

        // GET: /Checkout/PlaceOrder
        public ActionResult Complete(Guid id)
        {
            var response = _orderService.GetOrder(new GetOrderRequest { Id = id });

            var model = new CompleteCheckoutViewModel { OrderNumber = response.Order.OrderNumber };

            return View(model);
        }

        private Guid GetCartId()
        {
            var storedCartId = _cookieStorageService.Retrieve(CookieDataKeys.CartId.ToString());

            var cartId = Guid.Empty;

            if (!string.IsNullOrEmpty(storedCartId))
            {
                cartId = new Guid(storedCartId);
            }

            return cartId;
        }
    }
}