#region Using Directives

using System;
using System.Web.Mvc;

#endregion

namespace MusicStore.Services.Messaging.AlbumService
{
    public class CreateAlbumRequest
    {
        public Guid GenreId { get; set; }

        public Guid ArtistId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string AlbumArtUrl { get; set; }
    }
}