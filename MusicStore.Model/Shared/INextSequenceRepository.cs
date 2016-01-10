#region Using Directives

using System;
using MusicStore.Infrastructure.Domain;

#endregion

namespace MusicStore.Model.Shared
{
    public interface INextSequenceRepository : IReadOnlyRepository<NextSequenceNumber, int>
    {
    }
}