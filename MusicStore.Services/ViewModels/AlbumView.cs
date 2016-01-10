#region Using Directives

using System;

#endregion

namespace MusicStore.Services.ViewModels
{
    public class AlbumView
    {
        public Guid Id { get; set; }

        public GenreView Genre { get; set; }

        public ArtistView Artist { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Price { get; set; }

        public string AlbumArtUrl { get; set; }
    }
}