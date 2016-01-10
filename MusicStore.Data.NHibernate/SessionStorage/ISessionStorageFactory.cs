namespace MusicStore.Data.NHibernate.SessionStorage
{
    public interface ISessionStorageFactory
    {
        ISessionStorageContainer GetStorageContainer();
    }
}