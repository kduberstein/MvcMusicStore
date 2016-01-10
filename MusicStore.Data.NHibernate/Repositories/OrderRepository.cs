#region Using Directives

using System;
using MusicStore.Data.NHibernate.SessionStorage;
using MusicStore.Infrastructure.UnitOfWork;
using MusicStore.Model.Orders;

#endregion

namespace MusicStore.Data.NHibernate.Repositories
{
    public class OrderRepository : Repository<Order, Guid>, IOrderRepository
    {
        public OrderRepository(ISessionFactoryWrapper sessionFactory, IUnitOfWork uow) : base(sessionFactory, uow)
        {
        }
    }
}