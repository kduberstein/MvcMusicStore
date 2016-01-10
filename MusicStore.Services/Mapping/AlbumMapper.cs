#region Using Directives

using System.Collections.Generic;
using AutoMapper;
using MusicStore.Model.Products;
using MusicStore.Services.ViewModels;

#endregion

namespace MusicStore.Services.Mapping
{
    public static class AlbumMapper
    {
        public static AlbumView ConvertToAlbumView(this Album album)
        {
            return Mapper.Map<Album, AlbumView>(album);
        }

        public static IEnumerable<AlbumView> ConvertToAlbumViews(this IEnumerable<Album> albums)
        {
            return Mapper.Map<IEnumerable<Album>, IEnumerable<AlbumView>>(albums);
        }
    }
}