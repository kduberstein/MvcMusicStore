#region Using Directives

using System;

#endregion

namespace MusicStore.Services.ViewModels
{
    public class OrderItemView
    {
        public Guid Id { get; set; }

        public AlbumView Album { get; set; }

        public int Qty { get; set; }

        public string Description { get; set; }

        public string Price { get; set; }

        public string LineTotal { get; set; }
    }
}