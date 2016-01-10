#region Using Directives

using System;
using MusicStore.Infrastructure.Domain;

#endregion

namespace MusicStore.Model.Ecommerce
{
    public interface IUserLoginRepository : IRepository<UserLogin, Guid>
    {
    }
}