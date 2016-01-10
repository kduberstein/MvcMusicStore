#region Using Directives

using MusicStore.Services.Messaging.AlbumService;

#endregion

namespace MusicStore.Services.Interfaces
{
    public interface IAlbumService
    {
        CreateAlbumResponse CreateAlbum(CreateAlbumRequest request);

        DeleteAlbumResponse DeleteAlbum(DeleteAlbumRequest request);

        EditAlbumResponse EditAlbum(EditAlbumRequest request);

        GetAlbumResponse GetAlbum(GetAlbumRequest request);

        GetAllAlbumsResponse GetAllAlbums();
    }
}