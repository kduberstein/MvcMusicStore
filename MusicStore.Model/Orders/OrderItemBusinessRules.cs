#region Using Directives

using MusicStore.Infrastructure.Domain;

#endregion

namespace MusicStore.Model.Orders
{
    public static class OrderItemBusinessRules
    {
        public static readonly BusinessRule OrderRequired
            = new BusinessRule("Order", "An order item must be related to an order.");

        public static readonly BusinessRule AlbumRequired
            = new BusinessRule("Album", "An order item must be related to an album.");

        public static readonly BusinessRule QtyNonNegative
            = new BusinessRule("Qty", "An order item must have a positive qty value.");

        public static readonly BusinessRule DescriptionRequired
            = new BusinessRule("Description", "An order item must have a description.");

        public static readonly BusinessRule PriceNonNegative
            = new BusinessRule("Price", "An order item must have a non negative price value.");
    }
}