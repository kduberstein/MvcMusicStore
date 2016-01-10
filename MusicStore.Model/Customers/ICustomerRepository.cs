#region Using Directives

using System;
using MusicStore.Infrastructure.Domain;

#endregion

namespace MusicStore.Model.Customers
{
    public interface ICustomerRepository : IRepository<Customer, Guid>
    {
        bool Exists(string firstName, string lastName, string emailAddress);

        Customer FindByEmailAddress(string emailAddress);
    }
}