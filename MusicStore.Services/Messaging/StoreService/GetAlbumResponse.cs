#region Using Directives

using MusicStore.Services.ViewModels;

#endregion

namespace MusicStore.Services.Messaging.StoreService
{
    public class GetAlbumResponse
    {
        public AlbumView Album { get; set; }
    }
}