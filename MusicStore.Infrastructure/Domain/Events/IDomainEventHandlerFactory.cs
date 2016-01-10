namespace MusicStore.Infrastructure.Domain.Events
{
    public interface IDomainEventHandlerFactory
    {
        IDomainEventHandler[] GetHandlersForEvent(IDomainEvent @event);
    }
}