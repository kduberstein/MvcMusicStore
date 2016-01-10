#region Using Directives

using System.Collections.Generic;
using MusicStore.Services.ViewModels;

#endregion

namespace MusicStore.Services.Messaging.AlbumService
{
    public class GetAllAlbumsResponse
    {
        public IEnumerable<AlbumView> Albums { get; set; }
    }
}