#region Using Directives

using System;
using System.Collections.Generic;

#endregion

namespace MusicStore.Services.ViewModels
{
    public class CartView
    {
        public CartView()
        {
            Items = new List<CartItemView>();
        }

        public Guid Id { get; set; }

        public int NumberOfItems { get; set; }

        public decimal CartTotal { get; set; }

        public IList<CartItemView> Items { get; set; }
    }
}