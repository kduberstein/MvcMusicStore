#region Using Directives

using MusicStore.Services.Messaging.GenreService;

#endregion

namespace MusicStore.Services.Interfaces
{
    public interface IGenreService
    {
        CreateGenreResponse CreateGenre(CreateGenreRequest request);

        DeleteGenreResponse DeleteGenre(DeleteGenreRequest request);

        EditGenreResponse EditGenre(EditGenreRequest request);

        GetAllGenresResponse GetAllGenres();

        GetGenreResponse GetGenre(GetGenreRequest request);
    }
}