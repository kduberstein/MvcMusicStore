#region Using Directives

using AutoMapper;
using MusicStore.Model.Ecommerce;
using MusicStore.Model.Orders;
using MusicStore.Services.ViewModels;

#endregion

namespace MusicStore.Services.Mapping
{
    public static class CartMapper
    {
        public static CartView ConvertToCartView(this Cart cart)
        {
            return Mapper.Map<Cart, CartView>(cart);
        }

        public static Order ConvertToOrder(this Cart cart)
        {
            var order = new Order();

            foreach (var item in cart.Items)
            {
                order.AddItem(item.Album, item.Qty, item.Album.Title);
            }

            return order;
        }
    }
}