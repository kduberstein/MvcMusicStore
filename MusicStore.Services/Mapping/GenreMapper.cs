#region Using Directives

using System.Collections.Generic;
using AutoMapper;
using MusicStore.Model.Products;
using MusicStore.Services.ViewModels;

#endregion

namespace MusicStore.Services.Mapping
{
    public static class GenreMapper
    {
        public static GenreView ConvertToGenreView(this Genre genre)
        {
            return Mapper.Map<Genre, GenreView>(genre);
        }

        public static IEnumerable<GenreView> ConvertToGenreViews(this IEnumerable<Genre> genres)
        {
            return Mapper.Map<IEnumerable<Genre>, IEnumerable<GenreView>>(genres);
        }
    }
}