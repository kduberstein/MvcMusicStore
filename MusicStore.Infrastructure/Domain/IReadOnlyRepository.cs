#region Using Directives

using System.Collections.Generic;
using System.Data.SqlClient;
using MusicStore.Infrastructure.Querying;

#endregion

namespace MusicStore.Infrastructure.Domain
{
    public interface IReadOnlyRepository<out T, in TKey> where T : IAggregateRoot
    {
        long Count(Query query);

        bool Exists(Query query);

        T FindBy(TKey id);

        T FindBy(Query query);

        IEnumerable<T> FindAll();

        IEnumerable<T> FindAll(Query query);

        IEnumerable<T> FindAll(Query query, int firstResult, int pageSize);

        T ExecuteStoredProcedure(string procedureName, IList<SqlParameter> parameters);
    }
}