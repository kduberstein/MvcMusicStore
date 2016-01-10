namespace MusicStore.Infrastructure.Domain
{
    public interface IRepository<T, in TKey> : IReadOnlyRepository<T, TKey> where T : IAggregateRoot
    {
        bool Add(T entity);

        bool Update(T entity);

        bool Save(T entity);

        bool Remove(T entity);
    }
}