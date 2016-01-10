#region Using Directives

using System;
using System.Linq;
using System.Text;
using MusicStore.Infrastructure.UnitOfWork;
using MusicStore.Model.Products;
using MusicStore.Services.Interfaces;
using MusicStore.Services.Mapping;
using MusicStore.Services.Messaging.ArtistService;

#endregion

namespace MusicStore.Services.Implementations
{
    public class ArtistService : IArtistService
    {
        private readonly IArtistRepository _artistRepository;
        private readonly IUnitOfWork _uow;

        public ArtistService(IArtistRepository artistRepository, IUnitOfWork uow)
        {
            _artistRepository = artistRepository;
            _uow = uow;
        }

        public CreateArtistResponse CreateArtist(CreateArtistRequest request)
        {
            var response = new CreateArtistResponse();

            var artist = new Artist { Name = request.Name };

            ThrowExceptionIfArtistIsInvalid(artist);

            _artistRepository.Add(artist);

            _uow.Commit();

            MvcSiteMapProvider.SiteMaps.ReleaseSiteMap();

            response.Artist = artist.ConvertToArtistView();

            return response;
        }

        public DeleteArtistResponse DeleteArtist(DeleteArtistRequest request)
        {
            var response = new DeleteArtistResponse();

            var artist = _artistRepository.FindBy(request.Id);

            _artistRepository.Remove(artist);

            _uow.Commit();

            response.ArtistDeleted = true;

            return response;
        }

        public EditArtistResponse EditArtist(EditArtistRequest request)
        {
            var response = new EditArtistResponse();

            var artist = _artistRepository.FindBy(request.Id);

            artist.Name = request.Name;

            ThrowExceptionIfArtistIsInvalid(artist);

            _artistRepository.Save(artist);

            _uow.Commit();

            response.Artist = artist.ConvertToArtistView();

            return response;
        }

        public GetAllArtistsResponse GetAllArtists()
        {
            var response = new GetAllArtistsResponse();

            var artists = _artistRepository.FindAll();

            response.Artists = artists.ConvertToArtistViews();

            return response;
        }

        public GetArtistResponse GetArtist(GetArtistRequest request)
        {
            var response = new GetArtistResponse();

            var artist = _artistRepository.FindBy(request.Id);

            response.Artist = artist.ConvertToArtistView();

            return response;
        }

        private static void ThrowExceptionIfArtistIsInvalid(Artist artist)
        {
            if (!artist.GetBrokenRules().Any()) { return; }

            var brokenRules = new StringBuilder();

            brokenRules.AppendLine("There were problems saving the artist:");

            foreach (var businessRule in artist.GetBrokenRules())
            {
                brokenRules.AppendLine(businessRule.Rule);
            }

            throw new ApplicationException(brokenRules.ToString());
        }
    }
}