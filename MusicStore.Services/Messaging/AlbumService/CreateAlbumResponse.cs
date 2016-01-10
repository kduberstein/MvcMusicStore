#region Using Directives

using MusicStore.Services.ViewModels;

#endregion

namespace MusicStore.Services.Messaging.AlbumService
{
    public class CreateAlbumResponse
    {
        public AlbumView Album { get; set; }
    }
}