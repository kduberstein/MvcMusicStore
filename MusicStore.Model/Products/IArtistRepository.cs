#region Using Directives

using System;
using MusicStore.Infrastructure.Domain;

#endregion

namespace MusicStore.Model.Products
{
    public interface IArtistRepository : IRepository<Artist, Guid>
    {
    }
}