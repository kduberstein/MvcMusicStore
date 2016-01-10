#region Using Directives

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MusicStore.Infrastructure.UnitOfWork;
using MusicStore.Model.Ecommerce;
using MusicStore.Model.Products;
using MusicStore.Services.Interfaces;
using MusicStore.Services.Mapping;
using MusicStore.Services.Messaging.CartService;
using MusicStore.Services.ViewModels;

#endregion

namespace MusicStore.Services.Implementations
{
    public class CartService : ICartService
    {
        private readonly IAlbumRepository _albumRepository;
        private readonly ICartRepository _cartRepository;
        private readonly IUnitOfWork _uow;

        public CartService(IAlbumRepository albumRepository, ICartRepository cartRepository, IUnitOfWork uow)
        {
            _albumRepository = albumRepository;
            _cartRepository = cartRepository;
            _uow = uow;
        }

        public CreateCartResponse CreateCart(CreateCartRequest request)
        {
            var response = new CreateCartResponse();

            var cart = new Cart();

            AddAlbumsToCart(request.AlbumsToAdd, cart);

            ThrowExceptionIfCartIsInvalid(cart);

            _cartRepository.Add(cart);

            _uow.Commit();

            response.Cart = cart.ConvertToCartView();

            return response;
        }

        public EditCartResponse EditCart(EditCartRequest request)
        {
            var response = new EditCartResponse();

            var cart = _cartRepository.FindBy(request.Id);

            if (cart == null) { throw new CartDoesNotExistException(); }

            AddAlbumsToCart(request.ItemsToAdd, cart);

            UpdateLineQtys(request.ItemsToUpdate, cart);

            RemoveAlbumsFromCart(request.ItemsToRemove, cart);

            ThrowExceptionIfCartIsInvalid(cart);

            _cartRepository.Save(cart);

            _uow.Commit();

            response.Cart = cart.ConvertToCartView();

            return response;
        }

        public GetCartResponse GetCart(GetCartRequest request)
        {
            var response = new GetCartResponse();

            var cart = _cartRepository.FindBy(request.Id);

            var cartView = cart != null ? cart.ConvertToCartView() : new CartView();

            response.Cart = cartView;

            return response;
        }

        private void AddAlbumsToCart(IList<Guid> albumsToAdd, Cart cart)
        {
            if (!albumsToAdd.Any()) { return; }

            foreach (var album in albumsToAdd.Select(productId => _albumRepository.FindBy(productId)))
            {
                cart.Add(album);
            }
        }

        private void UpdateLineQtys(IEnumerable<AlbumQtyUpdateRequest> qtyUpdateRequests, Cart cart)
        {
            foreach (var qtyUpdateRequest in qtyUpdateRequests)
            {
                var album = _albumRepository.FindBy(qtyUpdateRequest.AlbumId);

                if (album != null)
                {
                    cart.ChangeQtyOfAlbum(qtyUpdateRequest.NewQty, album);
                }
            }
        }

        private void RemoveAlbumsFromCart(IEnumerable<Guid> productsToRemove, Cart cart)
        {
            foreach (
                var product in productsToRemove.Select(productId => _albumRepository.FindBy(productId)).Where(product => product != null))
            {
                cart.Remove(product);
            }
        }

        private static void ThrowExceptionIfCartIsInvalid(Cart cart)
        {
            if (!cart.GetBrokenRules().Any()) { return; }

            var brokenRules = new StringBuilder();

            brokenRules.AppendLine("There were problems saving the cart:");

            foreach (var businessRule in cart.GetBrokenRules())
            {
                brokenRules.AppendLine(businessRule.Rule);
            }

            throw new ApplicationException(brokenRules.ToString());
        }
    }
}