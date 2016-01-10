#region Using Directives

using MusicStore.Controllers.ViewModels.Cart;
using MusicStore.Services.ViewModels;

#endregion

namespace MusicStore.Controllers.Mapping
{
    public static class CartMapper
    {
        public static CartSummaryViewModel ConvertToCartSummaryViewModel(this CartView cartView)
        {
            return new CartSummaryViewModel { CartTotal = cartView.CartTotal, NumberOfItems = cartView.NumberOfItems };
        }
    }
}