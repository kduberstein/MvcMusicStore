#region Using Directives

using System.Collections.Generic;
using MusicStore.Services.ViewModels;

#endregion

namespace MusicStore.Services.Messaging.ArtistService
{
    public class GetAllArtistsResponse
    {
        public IEnumerable<ArtistView> Artists { get; set; }
    }
}