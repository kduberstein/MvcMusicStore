namespace MusicStore.Infrastructure.Domain.Events
{
    public interface IDomainEventHandler
    {
        void Execute();
    }

    public interface IDomainEventHandler<T> : IDomainEventHandler where T : IDomainEvent
    {
        T Event { get; set; }
    }
}