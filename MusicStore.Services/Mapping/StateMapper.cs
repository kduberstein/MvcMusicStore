#region Using Directives

using System.Collections.Generic;
using AutoMapper;
using MusicStore.Model.Customers;
using MusicStore.Services.ViewModels;

#endregion

namespace MusicStore.Services.Mapping
{
    public static class StateMapper
    {
        public static IEnumerable<StateView> ConvertToStateViews(this IEnumerable<State> states)
        {
            return Mapper.Map<IEnumerable<State>, IEnumerable<StateView>>(states);
        }
    }
}