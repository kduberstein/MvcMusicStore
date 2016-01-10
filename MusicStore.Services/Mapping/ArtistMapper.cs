#region Using Directives

using System.Collections.Generic;
using AutoMapper;
using MusicStore.Model.Products;
using MusicStore.Services.ViewModels;

#endregion

namespace MusicStore.Services.Mapping
{
    public static class ArtistMapper
    {
        public static ArtistView ConvertToArtistView(this Artist artist)
        {
            return Mapper.Map<Artist, ArtistView>(artist);
        }

        public static IEnumerable<ArtistView> ConvertToArtistViews(this IEnumerable<Artist> artists)
        {
            return Mapper.Map<IEnumerable<Artist>, IEnumerable<ArtistView>>(artists);
        }
    }
}