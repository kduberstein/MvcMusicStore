#region Using Directives

using System.Collections.Generic;
using MusicStore.Services.ViewModels;

#endregion

namespace MusicStore.Controllers.ViewModels.Store
{
    public class GenreMenuViewModel
    {
        public IEnumerable<GenreView> Genres { get; set; }
    }
}