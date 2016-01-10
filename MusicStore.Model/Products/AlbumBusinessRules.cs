#region Using Directives

using MusicStore.Infrastructure.Domain;

#endregion

namespace MusicStore.Model.Products
{
    public static class AlbumBusinessRules
    {
        public static readonly BusinessRule GenreRequired
            = new BusinessRule("Genre", "An album must be assigned a genre.");

        public static readonly BusinessRule ArtistRequired
            = new BusinessRule("Artist", "An album must be associated with an artist.");

        public static readonly BusinessRule TitleRequired
            = new BusinessRule("Title", "An album must have a title.");

        public static readonly BusinessRule PriceNonNegative
            = new BusinessRule("Price", "An album must have a non negative price value.");
    }
}