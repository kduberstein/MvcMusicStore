#region Using Directives

using System;
using MusicStore.Data.NHibernate.SessionStorage;
using MusicStore.Infrastructure.UnitOfWork;
using MusicStore.Model.Products;

#endregion

namespace MusicStore.Data.NHibernate.Repositories
{
    public class ArtistRepository : Repository<Artist, Guid>, IArtistRepository
    {
        public ArtistRepository(ISessionFactoryWrapper sessionFactory, IUnitOfWork uow) : base(sessionFactory, uow)
        {
        }
    }
}