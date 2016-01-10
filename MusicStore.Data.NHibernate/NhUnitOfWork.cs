#region Using Directives

using System;
using MusicStore.Data.NHibernate.SessionStorage;
using MusicStore.Infrastructure.Logging;
using MusicStore.Infrastructure.UnitOfWork;

#endregion

namespace MusicStore.Data.NHibernate
{
    public class NhUnitOfWork : IUnitOfWork
    {
        private readonly ILocalLogger _logger;
        private readonly ISessionFactoryWrapper _sessionFactoryWrapper;

        public NhUnitOfWork(ILocalLogger logger, ISessionFactoryWrapper sessionFactoryWrapper)
        {
            _logger = logger;
            _sessionFactoryWrapper = sessionFactoryWrapper;
        }

        public void Commit()
        {
            using (var transaction = _sessionFactoryWrapper.GetCurrentSession().BeginTransaction())
            {
                try
                {
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    _logger.LogError("An error occurred committing the transaction.", ex);

                    transaction.Rollback();

                    throw;
                }
            }
        }
    }
}