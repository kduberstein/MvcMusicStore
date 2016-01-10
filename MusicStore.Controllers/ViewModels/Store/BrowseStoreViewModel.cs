#region Using Directives

using System.Collections.Generic;
using MusicStore.Services.ViewModels;

#endregion

namespace MusicStore.Controllers.ViewModels.Store
{
    public class BrowseStoreViewModel
    {
        public string Genre { get; set; }

        public IEnumerable<AlbumView> Albums { get; set; }
    }
}