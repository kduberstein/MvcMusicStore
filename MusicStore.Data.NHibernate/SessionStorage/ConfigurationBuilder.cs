#region Using Directives

using NHibernate.Cfg;

#endregion

namespace MusicStore.Data.NHibernate.SessionStorage
{
    public class ConfigurationBuilder : IConfigurationBuilder
    {
        public Configuration BuildConfiguration()
        {
            return new Configuration().Configure();
        }
    }
}