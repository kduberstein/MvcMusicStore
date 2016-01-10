#region Using Directives

using System.Collections.Generic;
using MusicStore.Services.Interfaces;
using MvcSiteMapProvider;

#endregion

namespace MusicStore.Services.ViewModels.NodeProviders
{
    public class GenreDynamicNodeProvider : DynamicNodeProviderBase
    {
        private readonly IStoreService _storeService;

        public GenreDynamicNodeProvider(IStoreService storeService)
        {
            _storeService = storeService;
        }

        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode node)
        {
            var response = _storeService.GetAllGenres();

            foreach (var genre in response.Genres)
            {
                var dynamicNode = new DynamicNode("Genre_" + genre.Name, genre.Name);

                dynamicNode.RouteValues.Add("genre", genre.Name);

                yield return dynamicNode;
            }
        }
    }
}