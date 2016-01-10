#region Using Directives

using MusicStore.Model.Products;

#endregion

namespace MusicStore.Model.Ecommerce
{
    public static class CartItemFactory
    {
        public static CartItem CreateItemFor(Cart cart, Album album)
        {
            return new CartItem(cart, album, 1);
        }
    }
}