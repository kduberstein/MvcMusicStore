#region Using Directives

using System;
using MusicStore.Infrastructure.Domain;

#endregion

namespace MusicStore.Model.Products
{
    public class Album : EntityBase<Album, Guid>, IAggregateRoot
    {
        public virtual Genre Genre { get; set; }

        public virtual Artist Artist { get; set; }

        public virtual string Title { get; set; }

        public virtual string Description { get; set; }

        public virtual decimal Price { get; set; }

        public virtual string AlbumArtUrl { get; set; }

        protected override void Validate()
        {
            if (Genre == null) { AddBrokenRule(AlbumBusinessRules.GenreRequired); }

            if (Artist == null) { AddBrokenRule(AlbumBusinessRules.ArtistRequired); }

            if (string.IsNullOrEmpty(Title)) { AddBrokenRule(AlbumBusinessRules.TitleRequired); }

            if (Price < 0) { AddBrokenRule(AlbumBusinessRules.PriceNonNegative); }
        }
    }
}