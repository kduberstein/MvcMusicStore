#region Using Directives

using System.Collections.Generic;
using MusicStore.Services.ViewModels;

#endregion

namespace MusicStore.Controllers.ViewModels.Cart
{
    public class CartSummaryViewModel
    {
        public CartSummaryViewModel()
        {
            Items = new List<CartItemView>();
        }

        public int NumberOfItems { get; set; }

        public decimal CartTotal { get; set; }

        public IEnumerable<CartItemView> Items { get; set; }
    }
}