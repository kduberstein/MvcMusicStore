#region Using Directives

using MusicStore.Services.ViewModels;

#endregion

namespace MusicStore.Services.Messaging.GenreService
{
    public class CreateGenreResponse
    {
        public GenreView Genre { get; set; }
    }
}