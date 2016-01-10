#region Using Directives

using System;
using System.Linq;
using System.Web.Mvc;
using MusicStore.Controllers.ViewModels.Store;
using MusicStore.Services.Interfaces;
using MusicStore.Services.Messaging.StoreService;

#endregion

namespace MusicStore.Controllers.Controllers.Store
{
    public class StoreController : BaseController
    {
        private readonly IStoreService _storeService;

        public StoreController(IStoreService storeService)
        {
            _storeService = storeService;
        }

        // GET: /Store
        public ActionResult Index()
        {
            var response = _storeService.GetAllGenres();

            var model = new IndexStoreViewModel { Genres = response.Genres.OrderBy(g => g.Name) };

            return View(model);
        }

        // GET: /Store/Browse
        public ActionResult Browse(string genre)
        {
            var response = _storeService.GetAlbumsByGenre(new GetAlbumsByGenreRequest { Genre = genre });

            var model = new BrowseStoreViewModel { Albums = response.Albums, Genre = genre };

            return View(model);
        }

        // GET: /Store/Detail
        public ActionResult Detail(Guid id)
        {
            var response = _storeService.GetAlbum(new GetAlbumRequest { Id = id });

            var model = new DetailStoreViewModel { Album = response.Album };

            return View(model);
        }

        // GET: /Store/GenreMenu
        [ChildActionOnly]
        public ActionResult GenreMenu()
        {
            var response = _storeService.GetAllGenres();

            var model = new GenreMenuViewModel { Genres = response.Genres.OrderBy(g => g.Name) };

            return PartialView("_GenreMenu", model);
        }
    }
}