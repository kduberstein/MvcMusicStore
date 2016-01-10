#region Using Directives

using MusicStore.Services.ViewModels;

#endregion

namespace MusicStore.Services.Messaging.GenreService
{
    public class GetGenreResponse
    {
        public GenreView Genre { get; set; }
    }
}