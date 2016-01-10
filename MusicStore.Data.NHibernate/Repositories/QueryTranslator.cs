#region Using Directives

using System.Collections.Generic;
using System.ComponentModel;
using MusicStore.Infrastructure.Querying;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Util;

#endregion

namespace MusicStore.Data.NHibernate.Repositories
{
    public static class QueryTranslator
    {
        public static ICriteria TranslateIntoNhQuery<T>(this Query query, ICriteria criteria)
        {
            BuildQueryFrom<T>(query, criteria);

            if (query.OrderByProperty != null)
            {
                criteria.AddOrder(new Order(query.OrderByProperty.PropertyName, !query.OrderByProperty.Desc));
            }

            return criteria;
        }

        private static void BuildQueryFrom<T>(Query query, ICriteria criteria)
        {
            IList<ICriterion> critrions = new List<ICriterion>();

            foreach (var c in query.Criteria)
            {
                ICriterion criterion;

                if (query.Aliases.Any())
                {
                    foreach (var alias in query.Aliases)
                    {
                        criteria.CreateAlias(alias.AssociationPath, alias.Alias);
                    }
                }

                switch (c.CriteriaOperator)
                {
                    case CriteriaOperator.Equal:
                        criterion = Restrictions.Eq(c.PropertyName, c.Value);
                        break;
                    default:
                        throw new InvalidEnumArgumentException();
                }

                critrions.Add(criterion);
            }

            if (query.QueryOperator == QueryOperator.And)
            {
                var andSubQuery = Restrictions.Conjunction();

                foreach (var criterion in critrions)
                {
                    andSubQuery.Add(criterion);
                }

                criteria.Add(andSubQuery);
            }
            else
            {
                var orSubQuery = Restrictions.Disjunction();

                foreach (var criterion in critrions)
                {
                    orSubQuery.Add(criterion);
                }

                criteria.Add(orSubQuery);
            }

            foreach (var sub in query.SubQueries)
            {
                BuildQueryFrom<T>(sub, criteria);
            }
        }
    }
}