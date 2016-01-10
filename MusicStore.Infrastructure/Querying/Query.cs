#region Using Directives

using System.Collections.Generic;

#endregion

namespace MusicStore.Infrastructure.Querying
{
    public class Query
    {
        private readonly IList<QueryAlias> _aliases = new List<QueryAlias>();
        private readonly IList<Criterion> _criteria = new List<Criterion>();
        private readonly IList<Query> _subQueries = new List<Query>();

        public IList<QueryAlias> Aliases
        {
            get { return _aliases; }
        }

        public IEnumerable<Criterion> Criteria
        {
            get { return _criteria; }
        }

        public IEnumerable<Query> SubQueries
        {
            get { return _subQueries; }
        }

        public QueryOperator QueryOperator { get; set; }

        public OrderByClause OrderByProperty { get; set; }

        public void AddSubQuery(Query subQuery)
        {
            _subQueries.Add(subQuery);
        }

        public void Add(Criterion criterion)
        {
            _criteria.Add(criterion);
        }

        public void AddAlias(QueryAlias alias)
        {
            _aliases.Add(alias);
        }
    }
}