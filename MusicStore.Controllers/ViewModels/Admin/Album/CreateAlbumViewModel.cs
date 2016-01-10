#region Using Directives

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using MusicStore.Services.ViewModels;

#endregion

namespace MusicStore.Controllers.ViewModels.Admin.Album
{
    public class CreateAlbumViewModel
    {
        [Required(ErrorMessage = "Genre is required.")]
        public Guid GenreId { get; set; }

        public IEnumerable<GenreView> GenreLookupList { get; set; }

        [Required(ErrorMessage = "Artist is required.")]
        public Guid ArtistId { get; set; }

        public IEnumerable<ArtistView> ArtistLookupList { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }

        [AllowHtml]
        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        public string Price { get; set; }

        public string AlbumArtUrl { get; set; }
    }
}