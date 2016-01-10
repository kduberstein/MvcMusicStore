#region Using Directives

using System.Collections.Generic;
using MusicStore.Services.ViewModels;

#endregion

namespace MusicStore.Controllers.ViewModels.Admin.Artist
{
    public class IndexArtistViewModel
    {
        public IEnumerable<ArtistView> Artists { get; set; }
    }
}