#region Using Directives

using System;
using System.Linq;
using System.Web.Mvc;
using MusicStore.Controllers.ViewModels.Admin.Artist;
using MusicStore.Services.Interfaces;
using MusicStore.Services.Messaging.ArtistService;
using MvcSiteMapProvider.Web.Mvc.Filters;

#endregion

namespace MusicStore.Controllers.Controllers.Admin
{
    [Authorize]
    public class ArtistController : BaseController
    {
        private readonly IArtistService _artistService;

        public ArtistController(IArtistService artistService)
        {
            _artistService = artistService;
        }

        // GET: /Admin/Artist
        public ActionResult Index()
        {
            var response = _artistService.GetAllArtists();

            var model = new IndexArtistViewModel { Artists = response.Artists.OrderBy(g => g.Name) };

            return View(model);
        }

        // GET: /Admin/Artist/Detail
        [SiteMapTitle("Artist.Name", Target = AttributeTarget.CurrentNode)]
        public ActionResult Detail(Guid id)
        {
            var response = _artistService.GetArtist(new GetArtistRequest { Id = id });

            var model = new DetailArtistViewModel { Artist = response.Artist };

            return View(model);
        }

        // GET: /Admin/Artist/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Admin/Artist/Create
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(CreateArtistViewModel model)
        {
            if (!ModelState.IsValid) { return View(model); }

            var request = new CreateArtistRequest { Name = model.Name };

            _artistService.CreateArtist(request);

            return RedirectToAction("Index");
        }

        // GET: /Admin/Artist/Edit
        [SiteMapTitle("Name", Target = AttributeTarget.CurrentNode)]
        public ActionResult Edit(Guid id)
        {
            var response = _artistService.GetArtist(new GetArtistRequest { Id = id });

            var model = new EditArtistViewModel
            {
                Id = response.Artist.Id,
                Name = response.Artist.Name
            };

            return View(model);
        }

        // POST: /Admin/Artist/Edit
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(EditArtistViewModel model)
        {
            if (!ModelState.IsValid) { return View(model); }

            var request = new EditArtistRequest
            {
                Id = model.Id,
                Name = model.Name
            };

            _artistService.EditArtist(request);

            return RedirectToAction("Index");
        }

        // GET: /Admin/Artist/Delete
        [SiteMapTitle("Artist.Name", Target = AttributeTarget.CurrentNode)]
        public ActionResult Delete(Guid id)
        {
            var response = _artistService.GetArtist(new GetArtistRequest { Id = id });

            var model = new DeleteArtistViewModel { Artist = response.Artist };

            return View(model);
        }

        // POST: /Admin/Artist/Delete
        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _artistService.DeleteArtist(new DeleteArtistRequest { Id = id });

            return RedirectToAction("Index");
        }
    }
}