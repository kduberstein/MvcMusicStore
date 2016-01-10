#region Using Directives

using System.Collections.Generic;

#endregion

namespace MusicStore.Infrastructure.Domain.Events
{
    public interface IDomainEventRecorder
    {
        IEnumerable<IDomainEvent> Events { get; }
    }
}