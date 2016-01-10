#region Using Directives

using MusicStore.Model.Products;

#endregion

namespace MusicStore.Model.Orders
{
    public static class OrderItemFactory
    {
        public static OrderItem CreateItemFor(Album album, Order order, int qty, string description)
        {
            return new OrderItem(album, order, qty, description);
        }
    }
}