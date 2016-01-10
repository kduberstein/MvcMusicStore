#region Using Directives

using System;
using System.Linq;
using System.Web.Mvc;
using MusicStore.Controllers.ViewModels.Admin.Genre;
using MusicStore.Services.Interfaces;
using MusicStore.Services.Messaging.GenreService;
using MvcSiteMapProvider.Web.Mvc.Filters;

#endregion

namespace MusicStore.Controllers.Controllers.Admin
{
    [Authorize]
    public class GenreController : BaseController
    {
        private readonly IGenreService _genreService;

        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        // GET: /Admin/Genre
        public ActionResult Index()
        {
            var response = _genreService.GetAllGenres();

            var model = new IndexGenreViewModel { Genres = response.Genres.OrderBy(g => g.Name) };

            return View(model);
        }

        // GET: /Admin/Genre/Detail
        [SiteMapTitle("Genre.Name", Target = AttributeTarget.CurrentNode)]
        public ActionResult Detail(Guid id)
        {
            var response = _genreService.GetGenre(new GetGenreRequest { Id = id });

            var model = new DetailGenreViewModel { Genre = response.Genre };

            return View(model);
        }

        // GET: /Admin/Genre/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Admin/Genre/Create
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(CreateGenreViewModel model)
        {
            if (!ModelState.IsValid) { return View(model); }

            var request = new CreateGenreRequest { Name = model.Name, Description = model.Description };

            _genreService.CreateGenre(request);

            return RedirectToAction("Index");
        }

        // GET: /Admin/Genre/Edit
        [SiteMapTitle("Name", Target = AttributeTarget.CurrentNode)]
        public ActionResult Edit(Guid id)
        {
            var response = _genreService.GetGenre(new GetGenreRequest { Id = id });

            var model = new EditGenreViewModel
            {
                Id = response.Genre.Id,
                Name = response.Genre.Name,
                Description = response.Genre.Description
            };

            return View(model);
        }

        // POST: /Admin/Genre/Edit
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(EditGenreViewModel model)
        {
            if (!ModelState.IsValid) { return View(model); }

            var request = new EditGenreRequest
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description
            };

            _genreService.EditGenre(request);

            return RedirectToAction("Index");
        }

        // GET: /Admin/Genre/Delete
        [SiteMapTitle("Genre.Name", Target = AttributeTarget.CurrentNode)]
        public ActionResult Delete(Guid id)
        {
            var response = _genreService.GetGenre(new GetGenreRequest { Id = id });

            var model = new DeleteGenreViewModel { Genre = response.Genre };

            return View(model);
        }

        // POST: /Admin/Genre/Delete
        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _genreService.DeleteGenre(new DeleteGenreRequest { Id = id });

            return RedirectToAction("Index");
        }
    }
}