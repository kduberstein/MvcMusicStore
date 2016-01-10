#region Using Directives

using System;
using MusicStore.Data.NHibernate.SessionStorage;
using MusicStore.Infrastructure.UnitOfWork;
using MusicStore.Model.Ecommerce;

#endregion

namespace MusicStore.Data.NHibernate.Repositories
{
    public class CartRepository : Repository<Cart, Guid>, ICartRepository
    {
        public CartRepository(ISessionFactoryWrapper sessionFactory, IUnitOfWork uow) : base(sessionFactory, uow)
        {
        }
    }
}