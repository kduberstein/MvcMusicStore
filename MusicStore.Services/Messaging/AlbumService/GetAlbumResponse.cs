#region Using Directives

using MusicStore.Services.ViewModels;

#endregion

namespace MusicStore.Services.Messaging.AlbumService
{
    public class GetAlbumResponse
    {
        public AlbumView Album { get; set; }
    }
}