#region Using Directives

using NHibernate;

#endregion

namespace MusicStore.Data.NHibernate.SessionStorage
{
    public class SessionFactory : ISessionFactoryWrapper
    {
        private static ISessionFactory _sessionFactory;
        private readonly IConfigurationBuilder _configurationBuilder;
        private readonly ISessionStorageContainer _sessionStorageContainer;

        public SessionFactory(IConfigurationBuilder configurationBuilder, ISessionStorageContainer sessionStorageContainer)
        {
            _configurationBuilder = configurationBuilder;
            _sessionStorageContainer = sessionStorageContainer;
        }

        public ISession GetCurrentSession()
        {
            var currentSession = _sessionStorageContainer.GetCurrentSession();

            if (currentSession != null) { return currentSession; }

            currentSession = GetNewSession();

            _sessionStorageContainer.Store(currentSession);

            return currentSession;
        }

        private void Init()
        {
            var cfg = _configurationBuilder.BuildConfiguration();

            _sessionFactory = cfg.BuildSessionFactory();
        }

        private ISessionFactory GetSessionFactory()
        {
            if (_sessionFactory == null) { Init(); }

            return _sessionFactory;
        }

        private ISession GetNewSession()
        {
            return GetSessionFactory().OpenSession();
        }
    }
}