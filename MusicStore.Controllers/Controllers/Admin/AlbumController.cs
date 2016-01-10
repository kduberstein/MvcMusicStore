#region Using Directives

using System;
using System.Linq;
using System.Web.Mvc;
using MusicStore.Controllers.Mapping;
using MusicStore.Controllers.ViewModels.Admin.Album;
using MusicStore.Services.Interfaces;
using MusicStore.Services.Messaging.AlbumService;
using MvcSiteMapProvider.Web.Mvc.Filters;

#endregion

namespace MusicStore.Controllers.Controllers.Admin
{
    [Authorize]
    public class AlbumController : BaseController
    {
        private readonly IAlbumService _albumService;
        private readonly IArtistService _artistService;
        private readonly IGenreService _genreService;

        public AlbumController(IAlbumService albumService, IArtistService artistService, IGenreService genreService)
        {
            _albumService = albumService;
            _artistService = artistService;
            _genreService = genreService;
        }

        // GET: /Admin/Album
        public ActionResult Index()
        {
            var response = _albumService.GetAllAlbums();

            var model = new IndexAlbumViewModel
            {
                Albums = response.Albums.OrderBy(a => a.Genre.Name).ThenBy(a => a.Artist.Name).ThenBy(a => a.Title)
            };

            return View(model);
        }

        // GET: /Admin/Album/Detail
        [SiteMapTitle("Album.Title", Target = AttributeTarget.CurrentNode)]
        public ActionResult Detail(Guid id)
        {
            var response = _albumService.GetAlbum(new GetAlbumRequest { Id = id });

            var model = new DetailAlbumViewModel { Album = response.Album };

            return View(model);
        }

        // GET: /Admin/Album/Create
        public ActionResult Create()
        {
            var model = new CreateAlbumViewModel
            {
                GenreLookupList = _genreService.GetAllGenres().Genres.OrderBy(g => g.Name),
                ArtistLookupList = _artistService.GetAllArtists().Artists.OrderBy(a => a.Name)
            };

            return View(model);
        }

        // POST: /Admin/Album/Create
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(CreateAlbumViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.GenreLookupList = _genreService.GetAllGenres().Genres.OrderBy(g => g.Name);
                model.ArtistLookupList = _artistService.GetAllArtists().Artists.OrderBy(a => a.Name);

                return View(model);
            }

            _albumService.CreateAlbum(model.ConvertToCreateAlbumRequest());

            return RedirectToAction("Index");
        }

        // GET: /Admin/Album/Edit
        [SiteMapTitle("Title", Target = AttributeTarget.CurrentNode)]
        public ActionResult Edit(Guid id)
        {
            var response = _albumService.GetAlbum(new GetAlbumRequest { Id = id });

            var model = response.ConvertToEditAlbumViewModel();

            model.GenreLookupList = _genreService.GetAllGenres().Genres.OrderBy(g => g.Name);
            model.ArtistLookupList = _artistService.GetAllArtists().Artists.OrderBy(a => a.Name);

            return View(model);
        }

        // POST: /Admin/Album/Edit
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(EditAlbumViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.GenreLookupList = _genreService.GetAllGenres().Genres.OrderBy(g => g.Name);
                model.ArtistLookupList = _artistService.GetAllArtists().Artists.OrderBy(a => a.Name);

                return View(model);
            }

            _albumService.EditAlbum(model.ConvertToEditAlbumRequest());

            return RedirectToAction("Index");
        }

        // GET: /Admin/Album/Delete
        [SiteMapTitle("Album.Title", Target = AttributeTarget.CurrentNode)]
        public ActionResult Delete(Guid id)
        {
            var response = _albumService.GetAlbum(new GetAlbumRequest { Id = id });

            var model = new DeleteAlbumViewModel { Album = response.Album };

            return View(model);
        }

        // POST: /Admin/Album/Delete
        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _albumService.DeleteAlbum(new DeleteAlbumRequest { Id = id });

            return RedirectToAction("Index");
        }
    }

    
}