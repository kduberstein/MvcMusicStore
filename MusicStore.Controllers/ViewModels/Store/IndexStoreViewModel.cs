#region Using Directives

using System.Collections.Generic;
using System.Linq;
using MusicStore.Services.ViewModels;

#endregion

namespace MusicStore.Controllers.ViewModels.Store
{
    public class IndexStoreViewModel
    {
        public int Count
        {
            get { return Genres.Count(); }
        }

        public IEnumerable<GenreView> Genres { get; set; }
    }
}