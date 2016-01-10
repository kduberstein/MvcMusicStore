#region Using Directives

using System;
using MusicStore.Data.NHibernate.SessionStorage;
using MusicStore.Infrastructure.Querying;
using MusicStore.Infrastructure.UnitOfWork;
using MusicStore.Model.Customers;
using NHibernate.Criterion;

#endregion

namespace MusicStore.Data.NHibernate.Repositories
{
    public class CustomerRepository : Repository<Customer, Guid>, ICustomerRepository
    {
        private readonly ISessionFactoryWrapper _sessionFactory;

        public CustomerRepository(ISessionFactoryWrapper sessionFactory, IUnitOfWork uow) : base(sessionFactory, uow)
        {
            _sessionFactory = sessionFactory;
        }

        public bool Exists(string firstName, string lastName, string emailAddress)
        {
            return _sessionFactory.GetCurrentSession().CreateCriteria<Customer>()
                .Add(Restrictions.Eq(PropertyNameHelper.ResolvePropertyName<Customer>(c => c.FirstName), firstName))
                .Add(Restrictions.Eq(PropertyNameHelper.ResolvePropertyName<Customer>(c => c.LastName), lastName))
                .CreateAlias(PropertyNameHelper.ResolvePropertyName<Customer>(c => c.UserLogin), "user")
                .Add(Restrictions.Eq("user.Username", emailAddress))
                .UniqueResult<Customer>() != null;
        }

        public Customer FindByEmailAddress(string emailAddress)
        {
            return _sessionFactory.GetCurrentSession().CreateCriteria<Customer>()
                .CreateAlias(PropertyNameHelper.ResolvePropertyName<Customer>(c => c.UserLogin), "user")
                .Add(Restrictions.Eq("user.Username", emailAddress))
                .UniqueResult<Customer>();
        }
    }
}