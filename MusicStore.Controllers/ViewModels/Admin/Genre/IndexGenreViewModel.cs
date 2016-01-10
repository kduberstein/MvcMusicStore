#region Using Directives

using System.Collections.Generic;
using MusicStore.Services.ViewModels;

#endregion

namespace MusicStore.Controllers.ViewModels.Admin.Genre
{
    public class IndexGenreViewModel
    {
        public IEnumerable<GenreView> Genres { get; set; }
    }
}