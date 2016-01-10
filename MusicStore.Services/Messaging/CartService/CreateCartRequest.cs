#region Using Directives

using System;
using System.Collections.Generic;

#endregion

namespace MusicStore.Services.Messaging.CartService
{
    public class CreateCartRequest
    {
        public CreateCartRequest()
        {
            AlbumsToAdd = new List<Guid>();
        }

        public IList<Guid> AlbumsToAdd { get; set; }
    }
}