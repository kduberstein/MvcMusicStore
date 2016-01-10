#region Using Directives

using System.Collections.Generic;
using MusicStore.Services.ViewModels;

#endregion

namespace MusicStore.Services.Messaging.StoreService
{
    public class GetAlbumsByGenreResponse
    {
        public IEnumerable<AlbumView> Albums { get; set; }
    }
}