#region Using Directives

using MusicStore.Services.Messaging.ArtistService;

#endregion

namespace MusicStore.Services.Interfaces
{
    public interface IArtistService
    {
        CreateArtistResponse CreateArtist(CreateArtistRequest request);

        DeleteArtistResponse DeleteArtist(DeleteArtistRequest request);

        EditArtistResponse EditArtist(EditArtistRequest request);

        GetAllArtistsResponse GetAllArtists();

        GetArtistResponse GetArtist(GetArtistRequest request);
    }
}