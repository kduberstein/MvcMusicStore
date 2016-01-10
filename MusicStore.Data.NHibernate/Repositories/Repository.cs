#region Using Directives

using System.Collections.Generic;
using System.Data.SqlClient;
using MusicStore.Data.NHibernate.SessionStorage;
using MusicStore.Infrastructure.Domain;
using MusicStore.Infrastructure.Querying;
using MusicStore.Infrastructure.UnitOfWork;
using NHibernate;
using NHibernate.Criterion;

#endregion

namespace MusicStore.Data.NHibernate.Repositories
{
    public abstract class Repository<T, TKey> : IRepository<T, TKey> where T : IAggregateRoot
    {
        private readonly ISessionFactoryWrapper _sessionFactory;
        private readonly IUnitOfWork _uow;

        protected Repository(ISessionFactoryWrapper sessionFactory, IUnitOfWork uow)
        {
            _sessionFactory = sessionFactory;
            _uow = uow;
        }

        public IUnitOfWork Uow
        {
            get { return _uow; }
        }

        public long Count(Query query)
        {
            return CreateCriteriaQuery(query).SetProjection(Projections.RowCountInt64()).UniqueResult<long>();
        }

        public bool Exists(Query query)
        {
            return Count(query) > 0;
        }

        public T FindBy(TKey id)
        {
            return _sessionFactory.GetCurrentSession().Get<T>(id);
        }

        public T FindBy(Query query)
        {
            return CreateCriteriaQuery(query).UniqueResult<T>();
        }

        public IEnumerable<T> FindAll()
        {
            return _sessionFactory.GetCurrentSession().CreateCriteria(typeof (T)).List<T>();
        }

        public IEnumerable<T> FindAll(Query query)
        {
            return CreateCriteriaQuery(query).List<T>();
        }

        public IEnumerable<T> FindAll(Query query, int firstResult, int pageSize)
        {
            return CreateCriteriaQuery(query).SetFirstResult(firstResult).SetMaxResults(pageSize).List<T>();
        }

        public T ExecuteStoredProcedure(string procedureName, IList<SqlParameter> parameters)
        {
            var query = _sessionFactory.GetCurrentSession().GetNamedQuery(procedureName);

            AddStoredProcedureParameters(query, parameters);

            return query.UniqueResult<T>();
        }

        public bool Add(T entity)
        {
            _sessionFactory.GetCurrentSession().Save(entity);

            return true;
        }

        public bool Update(T entity)
        {
            _sessionFactory.GetCurrentSession().Update(entity);

            return true;
        }

        public bool Save(T entity)
        {
            _sessionFactory.GetCurrentSession().SaveOrUpdate(entity);

            return true;
        }

        public bool Remove(T entity)
        {
            _sessionFactory.GetCurrentSession().Delete(entity);

            return true;
        }

        private ICriteria CreateCriteriaQuery(Query query)
        {
            var criteriaQuery = _sessionFactory.GetCurrentSession().CreateCriteria(typeof (T));

            AppendCriteria(criteriaQuery);

            return query.TranslateIntoNhQuery<T>(criteriaQuery);
        }

        private static void AddStoredProcedureParameters(IQuery query, IEnumerable<SqlParameter> parameters)
        {
            foreach (var parameter in parameters)
            {
                query.SetParameter(parameter.ParameterName, parameter.Value);
            }
        }

        public virtual void AppendCriteria(ICriteria criteria)
        {
        }
    }
}