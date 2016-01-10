#region Using Directives

using System;

#endregion

namespace MusicStore.Services.Messaging.CartService
{
    public class AlbumQtyUpdateRequest
    {
        public Guid AlbumId { get; set; }

        public int NewQty { get; set; }
    }
}