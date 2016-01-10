#region Using Directives

using System;
using MusicStore.Data.NHibernate.SessionStorage;
using MusicStore.Infrastructure.UnitOfWork;
using MusicStore.Model.Products;

#endregion

namespace MusicStore.Data.NHibernate.Repositories
{
    public class AlbumRepository : Repository<Album, Guid>, IAlbumRepository
    {
        public AlbumRepository(ISessionFactoryWrapper sessionFactory, IUnitOfWork uow) : base(sessionFactory, uow)
        {
        }
    }
}