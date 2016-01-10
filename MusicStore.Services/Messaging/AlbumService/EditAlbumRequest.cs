#region Using Directives

using System;

#endregion

namespace MusicStore.Services.Messaging.AlbumService
{
    public class EditAlbumRequest
    {
        public Guid Id { get; set; }

        public Guid GenreId { get; set; }

        public Guid ArtistId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string AlbumArtUrl { get; set; }
    }
}