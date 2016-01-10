#region Using Directives

using System;
using MusicStore.Infrastructure.Helpers;

#endregion

namespace MusicStore.Services.ViewModels
{
    public class CartItemView
    {
        public Guid Id { get; set; }

        public AlbumView Album { get; set; }

        public int Qty { get; set; }

        public decimal LineTotal
        {
            get { return Qty * Album.Price.UnFormatMoney(); }
        }
    }
}