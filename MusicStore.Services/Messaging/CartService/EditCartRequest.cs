#region Using Directives

using System;
using System.Collections.Generic;

#endregion

namespace MusicStore.Services.Messaging.CartService
{
    public class EditCartRequest
    {
        public EditCartRequest()
        {
            ItemsToAdd = new List<Guid>();
            ItemsToUpdate = new List<AlbumQtyUpdateRequest>();
            ItemsToRemove = new List<Guid>();
        }

        public Guid Id { get; set; }

        public IList<Guid> ItemsToAdd { get; set; }

        public IList<AlbumQtyUpdateRequest> ItemsToUpdate { get; set; }

        public IList<Guid> ItemsToRemove { get; set; }
    }
}