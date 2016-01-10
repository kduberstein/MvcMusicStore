#region Using Directives

using System;
using MusicStore.Infrastructure.Domain;

#endregion

namespace MusicStore.Model.Orders
{
    public interface IOrderRepository : IRepository<Order, Guid>
    {
    }
}