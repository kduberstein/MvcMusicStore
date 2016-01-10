#region Using Directives

using System;
using System.Linq.Expressions;

#endregion

namespace MusicStore.Infrastructure.Querying
{
    public class QueryAlias
    {
        private readonly string _alias;
        private readonly string _associationPath;

        public QueryAlias(string associationPath, string alias)
        {
            _associationPath = associationPath;
            _alias = alias;
        }

        public string Alias
        {
            get { return _alias; }
        }

        public string AssociationPath
        {
            get { return _associationPath; }
        }

        public static QueryAlias CreateAlias<T>(Expression<Func<T, object>> expression)
        {
            var associationPath = PropertyNameHelper.ResolvePropertyName(expression);

            return new QueryAlias(PropertyNameHelper.ResolvePropertyName(expression),
                char.ToLowerInvariant(associationPath[0]) + associationPath.Substring(1));
        }
    }
}