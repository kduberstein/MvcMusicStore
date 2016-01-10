#region Using Directives

using NHibernate;

#endregion

namespace MusicStore.Data.NHibernate.SessionStorage
{
    public interface ISessionFactoryWrapper
    {
        ISession GetCurrentSession();
    }
}