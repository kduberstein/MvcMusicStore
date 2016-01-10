#region Using Directives

using NHibernate;

#endregion

namespace MusicStore.Data.NHibernate.SessionStorage
{
    public interface ISessionStorageContainer
    {
        ISession GetCurrentSession();

        void Store(ISession session);
    }
}