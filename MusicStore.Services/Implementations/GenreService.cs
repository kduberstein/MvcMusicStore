#region Using Directives

using System;
using System.Linq;
using System.Text;
using MusicStore.Infrastructure.UnitOfWork;
using MusicStore.Model.Products;
using MusicStore.Services.Interfaces;
using MusicStore.Services.Mapping;
using MusicStore.Services.Messaging.GenreService;

#endregion

namespace MusicStore.Services.Implementations
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IUnitOfWork _uow;

        public GenreService(IGenreRepository genreRepository, IUnitOfWork uow)
        {
            _genreRepository = genreRepository;
            _uow = uow;
        }

        public CreateGenreResponse CreateGenre(CreateGenreRequest request)
        {
            var response = new CreateGenreResponse();

            var genre = new Genre { Name = request.Name, Description = request.Description };

            ThrowExceptionIfGenreIsInvalid(genre);

            _genreRepository.Add(genre);

            _uow.Commit();

            MvcSiteMapProvider.SiteMaps.ReleaseSiteMap();

            response.Genre = genre.ConvertToGenreView();

            return response;
        }

        public DeleteGenreResponse DeleteGenre(DeleteGenreRequest request)
        {
            var response = new DeleteGenreResponse();

            var genre = _genreRepository.FindBy(request.Id);

            _genreRepository.Remove(genre);

            _uow.Commit();

            response.GenreDeleted = true;

            return response;
        }

        public EditGenreResponse EditGenre(EditGenreRequest request)
        {
            var response = new EditGenreResponse();

            var genre = _genreRepository.FindBy(request.Id);

            genre.Name = request.Name;
            genre.Description = request.Description;

            ThrowExceptionIfGenreIsInvalid(genre);

            _genreRepository.Save(genre);

            _uow.Commit();

            response.Genre = genre.ConvertToGenreView();

            return response;
        }

        public GetAllGenresResponse GetAllGenres()
        {
            var response = new GetAllGenresResponse();

            var genres = _genreRepository.FindAll();

            response.Genres = genres.ConvertToGenreViews();

            return response;
        }

        public GetGenreResponse GetGenre(GetGenreRequest request)
        {
            var response = new GetGenreResponse();

            var genre = _genreRepository.FindBy(request.Id);

            response.Genre = genre.ConvertToGenreView();

            return response;
        }

        private static void ThrowExceptionIfGenreIsInvalid(Genre genre)
        {
            if (!genre.GetBrokenRules().Any()) { return; }

            var brokenRules = new StringBuilder();

            brokenRules.AppendLine("There were problems saving the genre:");

            foreach (var businessRule in genre.GetBrokenRules())
            {
                brokenRules.AppendLine(businessRule.Rule);
            }

            throw new ApplicationException(brokenRules.ToString());
        }
    }
}