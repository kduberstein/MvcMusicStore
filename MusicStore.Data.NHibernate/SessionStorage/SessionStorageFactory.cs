namespace MusicStore.Data.NHibernate.SessionStorage
{
    public class SessionStorageFactory : ISessionStorageFactory
    {
        private readonly ISessionStorageContainer _nhSessionStorageContainer;

        public SessionStorageFactory(ISessionStorageContainer nhSessionStorageContainer)
        {
            _nhSessionStorageContainer = nhSessionStorageContainer;
        }

        public ISessionStorageContainer GetStorageContainer()
        {
            return _nhSessionStorageContainer;
        }
    }
}