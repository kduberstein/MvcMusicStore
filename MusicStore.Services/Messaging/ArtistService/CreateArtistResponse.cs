#region Using Directives

using MusicStore.Services.ViewModels;

#endregion

namespace MusicStore.Services.Messaging.ArtistService
{
    public class CreateArtistResponse
    {
        public ArtistView Artist { get; set; }
    }
}