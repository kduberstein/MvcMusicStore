#region Using Directives

using MusicStore.Data.NHibernate.SessionStorage;
using MusicStore.Infrastructure.UnitOfWork;
using MusicStore.Model.Shared;

#endregion

namespace MusicStore.Data.NHibernate.Repositories
{
    public class NextSequenceRepository : Repository<NextSequenceNumber, int>, INextSequenceRepository
    {
        public NextSequenceRepository(ISessionFactoryWrapper sessionFactory, IUnitOfWork uow) : base(sessionFactory, uow)
        {
        }
    }
}