#region Using Directives

using MusicStore.Services.Messaging.StoreService;

#endregion

namespace MusicStore.Services.Interfaces
{
    public interface IStoreService
    {
        GetAlbumResponse GetAlbum(GetAlbumRequest request);

        GetAlbumsByGenreResponse GetAlbumsByGenre(GetAlbumsByGenreRequest request);

        GetAllGenresResponse GetAllGenres();
    }
}