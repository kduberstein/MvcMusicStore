#region Using Directives

using NHibernate.Cfg;

#endregion

namespace MusicStore.Data.NHibernate.SessionStorage
{
    public interface IConfigurationBuilder
    {
        Configuration BuildConfiguration();
    }
}