#region Using Directives

using System.Collections.Generic;
using MusicStore.Services.ViewModels;

#endregion

namespace MusicStore.Controllers.ViewModels.Admin.Album
{
    public class IndexAlbumViewModel
    {
        public IEnumerable<AlbumView> Albums { get; set; }
    }
}