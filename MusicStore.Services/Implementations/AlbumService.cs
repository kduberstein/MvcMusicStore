#region Using Directives

using System;
using System.Linq;
using System.Text;
using MusicStore.Infrastructure.UnitOfWork;
using MusicStore.Model.Products;
using MusicStore.Services.Interfaces;
using MusicStore.Services.Mapping;
using MusicStore.Services.Messaging.AlbumService;

#endregion

namespace MusicStore.Services.Implementations
{
    public class AlbumService : IAlbumService
    {
        private readonly IAlbumRepository _albumRepository;
        private readonly IArtistRepository _artistRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly IUnitOfWork _uow;

        public AlbumService(IAlbumRepository albumRepository, IArtistRepository artistRepository, IGenreRepository genreRepository,
            IUnitOfWork uow)
        {
            _albumRepository = albumRepository;
            _artistRepository = artistRepository;
            _genreRepository = genreRepository;
            _uow = uow;
        }

        public CreateAlbumResponse CreateAlbum(CreateAlbumRequest request)
        {
            var response = new CreateAlbumResponse();

            var album = new Album
            {
                Genre = _genreRepository.FindBy(request.GenreId),
                Artist = _artistRepository.FindBy(request.ArtistId),
                Title = request.Title,
                Description = request.Description,
                Price = request.Price,
                AlbumArtUrl = request.AlbumArtUrl
            };

            ThrowExceptionIfAlbumIsInvalid(album);

            _albumRepository.Add(album);

            _uow.Commit();

            MvcSiteMapProvider.SiteMaps.ReleaseSiteMap();

            response.Album = album.ConvertToAlbumView();

            return response;
        }

        public DeleteAlbumResponse DeleteAlbum(DeleteAlbumRequest request)
        {
            var response = new DeleteAlbumResponse();

            var album = _albumRepository.FindBy(request.Id);

            _albumRepository.Remove(album);

            _uow.Commit();

            response.AlbumDeleted = true;

            return response;
        }

        public EditAlbumResponse EditAlbum(EditAlbumRequest request)
        {
            var response = new EditAlbumResponse();

            var album = _albumRepository.FindBy(request.Id);

            album.Genre = _genreRepository.FindBy(request.GenreId);
            album.Artist = _artistRepository.FindBy(request.ArtistId);
            album.Title = request.Title;
            album.Description = request.Description;
            album.Price = request.Price;
            album.AlbumArtUrl = request.AlbumArtUrl;

            ThrowExceptionIfAlbumIsInvalid(album);

            _albumRepository.Save(album);

            _uow.Commit();

            response.Album = album.ConvertToAlbumView();

            return response;
        }

        public GetAlbumResponse GetAlbum(GetAlbumRequest request)
        {
            var response = new GetAlbumResponse();

            var album = _albumRepository.FindBy(request.Id);

            response.Album = album.ConvertToAlbumView();

            return response;
        }

        public GetAllAlbumsResponse GetAllAlbums()
        {
            var response = new GetAllAlbumsResponse();

            var albums = _albumRepository.FindAll();

            response.Albums = albums.ConvertToAlbumViews();

            return response;
        }

        private static void ThrowExceptionIfAlbumIsInvalid(Album album)
        {
            if (!album.GetBrokenRules().Any()) { return; }

            var brokenRules = new StringBuilder();

            brokenRules.AppendLine("There were problems saving the album:");

            foreach (var businessRule in album.GetBrokenRules())
            {
                brokenRules.AppendLine(businessRule.Rule);
            }

            throw new ApplicationException(brokenRules.ToString());
        }
    }
}