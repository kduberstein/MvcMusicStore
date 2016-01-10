#region Using Directives

using System.Collections.Generic;
using MusicStore.Services.ViewModels;

#endregion

namespace MusicStore.Services.Messaging.GenreService
{
    public class GetAllGenresResponse
    {
        public IEnumerable<GenreView> Genres { get; set; }
    }
}