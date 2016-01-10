#region Using Directives

using System;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using MusicStore.Controllers.Attributes;
using MusicStore.Controllers.DataKeys;
using MusicStore.Controllers.Mapping;
using MusicStore.Controllers.ViewModels.Cart;
using MusicStore.Infrastructure.CookieStorage;
using MusicStore.Infrastructure.Helpers;
using MusicStore.Services.Implementations;
using MusicStore.Services.Interfaces;
using MusicStore.Services.Messaging.AlbumService;
using MusicStore.Services.Messaging.CartService;

#endregion

namespace MusicStore.Controllers.Controllers.Cart
{
    public class CartController : BaseController
    {
        private readonly IAlbumService _albumService;
        private readonly ICartService _cartService;
        private readonly ICookieStorageService _cookieStorageService;

        public CartController(IAlbumService albumService, ICartService cartService, ICookieStorageService cookieStorageService)
        {
            _albumService = albumService;
            _cartService = cartService;
            _cookieStorageService = cookieStorageService;
        }

        // GET: /Cart
        public ActionResult Index()
        {
            var cartId = GetCartId();

            var response = _cartService.GetCart(new GetCartRequest { Id = cartId });

            var model = new IndexCartViewModel { Cart = response.Cart };

            return View(model);
        }

        // GET: /Cart/Add
        public ActionResult Add(Guid id)
        {
            var cartId = GetCartId();

            var createNewCart = cartId == Guid.Empty;

            CartSummaryViewModel summaryModel;

            if (createNewCart == false)
            {
                var editCartRequest = new EditCartRequest();

                editCartRequest.ItemsToAdd.Add(id);

                editCartRequest.Id = cartId;

                try
                {
                    var editCartResponse = _cartService.EditCart(editCartRequest);

                    summaryModel = editCartResponse.Cart.ConvertToCartSummaryViewModel();

                    SaveCartSummaryToCookie(summaryModel.NumberOfItems, summaryModel.CartTotal.ToString(CultureInfo.InvariantCulture));
                }
                catch (CartDoesNotExistException)
                {
                    createNewCart = true;
                }
            }

            if (!createNewCart) { return RedirectToLocal("/Cart"); }

            var createCartRequest = new CreateCartRequest();

            createCartRequest.AlbumsToAdd.Add(id);

            var response = _cartService.CreateCart(createCartRequest);

            SaveCartIdToCookie(response.Cart.Id);

            summaryModel = response.Cart.ConvertToCartSummaryViewModel();

            SaveCartSummaryToCookie(summaryModel.NumberOfItems, summaryModel.CartTotal.ToString(CultureInfo.InvariantCulture));

            return RedirectToLocal("/Cart");
        }

        // AJAX: /Cart/Update
        [HttpPost]
        public ActionResult Update(Guid cartItemId, Guid albumId, int newQty)
        {
            var qtyUpdateRequest = new AlbumQtyUpdateRequest { AlbumId = albumId, NewQty = newQty };

            var request = new EditCartRequest();

            request.ItemsToUpdate.Add(qtyUpdateRequest);
            request.Id = GetCartId();

            var response = _cartService.EditCart(request);

            SaveCartSummaryToCookie(response.Cart.NumberOfItems, response.Cart.CartTotal.ToString(CultureInfo.InvariantCulture));

            var albumName = response.Cart.Items.Single(item => item.Album.Id == albumId).Album.Title;

            var results = new UpdateCartItemViewModel
            {
                Message = "The qty of " + Server.HtmlEncode(albumName) + " has been refreshed in your shopping cart.",
                CartTotal = response.Cart.CartTotal.FormatMoney(),
                CartCount = response.Cart.NumberOfItems,
                ItemQty = response.Cart.Items.Single(item => item.Album.Id == albumId).Qty,
                DeleteId = cartItemId
            };

            return Json(results);
        }

        // AJAX: /Cart/Remove
        [HttpPost]
        public ActionResult Remove(Guid cartItemId, Guid albumId)
        {
            var album = _albumService.GetAlbum(new GetAlbumRequest { Id = albumId }).Album;

            var request = new EditCartRequest();

            request.ItemsToRemove.Add(albumId);
            request.Id = GetCartId();

            var response = _cartService.EditCart(request);

            SaveCartSummaryToCookie(response.Cart.NumberOfItems, response.Cart.CartTotal.ToString(CultureInfo.InvariantCulture));

            var results = new RemoveCartItemViewModel
            {
                Message = Server.HtmlEncode(album.Title) + " has been removed from your cart.",
                CartTotal = response.Cart.CartTotal.FormatMoney(),
                CartCount = response.Cart.NumberOfItems,
                ItemQty = 0,
                DeleteId = cartItemId
            };

            return Json(results);
        }

        // GET: /Cart/CartSummary
        [AjaxChildActionOnly]
        public ActionResult CartSummary()
        {
            var cartId = GetCartId();

            var response = _cartService.GetCart(new GetCartRequest { Id = cartId });

            var model = new CartSummaryViewModel
            {
                Items = response.Cart.Items,
                NumberOfItems = response.Cart.NumberOfItems,
                CartTotal = response.Cart.CartTotal
            };

            return PartialView("_CartSummary", model);
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

        private void SaveCartIdToCookie(Guid cartId)
        {
            _cookieStorageService.Save(CookieDataKeys.CartId.ToString(), cartId.ToString(), DateTime.Now.AddDays(7));
        }

        private void SaveCartSummaryToCookie(int numberOfItems, string cartTotal)
        {
            _cookieStorageService.Save(CookieDataKeys.CartItems.ToString(), numberOfItems.ToString(), DateTime.Now.AddDays(7));

            _cookieStorageService.Save(CookieDataKeys.CartTotal.ToString(), cartTotal, DateTime.Now.AddDays(7));
        }
    }
}