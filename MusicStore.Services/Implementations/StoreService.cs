#region Using Directives

using MusicStore.Infrastructure.Querying;
using MusicStore.Model.Products;
using MusicStore.Services.Interfaces;
using MusicStore.Services.Mapping;
using MusicStore.Services.Messaging.StoreService;

#endregion

namespace MusicStore.Services.Implementations
{
    public class StoreService : IStoreService
    {
        private readonly IAlbumRepository _albumRepository;
        private readonly IGenreRepository _genreRepository;

        public StoreService(IAlbumRepository albumRepository, IGenreRepository genreRepository)
        {
            _albumRepository = albumRepository;
            _genreRepository = genreRepository;
        }

        public GetAlbumResponse GetAlbum(GetAlbumRequest request)
        {
            var response = new GetAlbumResponse();

            var album = _albumRepository.FindBy(request.Id);

            response.Album = album.ConvertToAlbumView();

            return response;
        }

        public GetAlbumsByGenreResponse GetAlbumsByGenre(GetAlbumsByGenreRequest request)
        {
            var response = new GetAlbumsByGenreResponse();

            var albumQuery = new Query();

            albumQuery.AddAlias(QueryAlias.CreateAlias<Album>(g => g.Genre));

            albumQuery.Add(Criterion.Create<Album, Genre>(a => a.Genre, g => g.Name, request.Genre, CriteriaOperator.Equal));

            var albums = _albumRepository.FindAll(albumQuery);

            response.Albums = albums.ConvertToAlbumViews();

            return response;
        }

        public GetAllGenresResponse GetAllGenres()
        {
            var response = new GetAllGenresResponse();

            var genres = _genreRepository.FindAll();

            response.Genres = genres.ConvertToGenreViews();

            return response;
        }
    }
}