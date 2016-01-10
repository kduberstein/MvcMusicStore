#region Using Directives

using System;
using MusicStore.Data.NHibernate.SessionStorage;
using MusicStore.Infrastructure.UnitOfWork;
using MusicStore.Model.Ecommerce;

#endregion

namespace MusicStore.Data.NHibernate.Repositories
{
    public class UserLoginRepository : Repository<UserLogin, Guid>, IUserLoginRepository
    {
        public UserLoginRepository(ISessionFactoryWrapper sessionFactory, IUnitOfWork uow) : base(sessionFactory, uow)
        {
        }
    }
}