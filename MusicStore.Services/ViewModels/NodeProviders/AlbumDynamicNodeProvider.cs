#region Using Directives

using System.Collections.Generic;
using MusicStore.Services.Interfaces;
using MvcSiteMapProvider;

#endregion

namespace MusicStore.Services.ViewModels.NodeProviders
{
    public class AlbumDynamicNodeProvider : DynamicNodeProviderBase
    {
        private readonly IAlbumService _albumService;

        public AlbumDynamicNodeProvider(IAlbumService albumService)
        {
            _albumService = albumService;
        }

        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode node)
        {
            var response = _albumService.GetAllAlbums();

            foreach (var album in response.Albums)
            {
                var dynamicNode = new DynamicNode
                {
                    Title = album.Title,
                    ParentKey = "Genre_" + album.Genre.Name
                };

                dynamicNode.RouteValues.Add("id", album.Id);

                yield return dynamicNode;
            }
        }
    }
}