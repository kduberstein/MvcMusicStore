#region Using Directives

using MusicStore.Infrastructure.Domain;

#endregion

namespace MusicStore.Model.Ecommerce
{
    public static class CartItemBusinessRules
    {
        public static readonly BusinessRule CartRequired
            = new BusinessRule("Cart", "A cart item must be related to a cart.");

        public static readonly BusinessRule AlbumRequired
            = new BusinessRule("Cart", "A cart item must be related to an album.");

        public static readonly BusinessRule QtyInvalid
            = new BusinessRule("Cart", "The qty of a cart item cannot be negative.");
    }
}