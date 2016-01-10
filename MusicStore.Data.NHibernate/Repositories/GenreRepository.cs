#region Using Directives

using System;
using MusicStore.Data.NHibernate.SessionStorage;
using MusicStore.Infrastructure.UnitOfWork;
using MusicStore.Model.Products;

#endregion

namespace MusicStore.Data.NHibernate.Repositories
{
    public class GenreRepository : Repository<Genre, Guid>, IGenreRepository
    {
        public GenreRepository(ISessionFactoryWrapper sessionFactory, IUnitOfWork uow) : base(sessionFactory, uow)
        {
        }
    }
}