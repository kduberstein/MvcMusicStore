#region Using Directives

using System;
using System.Linq.Expressions;

#endregion

namespace MusicStore.Infrastructure.Querying
{
    public class Criterion
    {
        public Criterion(string propertyName, object value, CriteriaOperator criteriaOperator)
        {
            PropertyName = propertyName;
            Value = value;
            CriteriaOperator = criteriaOperator;
        }

        public string PropertyName { get; private set; }

        public object Value { get; private set; }

        public CriteriaOperator CriteriaOperator { get; private set; }

        public static Criterion Create<T>(Expression<Func<T, object>> expression, object value,
            CriteriaOperator criteriaOperator)
        {
            var propertyName = PropertyNameHelper.ResolvePropertyName(expression);

            return new Criterion(propertyName, value, criteriaOperator);
        }

        public static Criterion Create<T, TU>(Expression<Func<T, object>> associationExpression,
            Expression<Func<TU, object>> childExpression, object value, CriteriaOperator criteriaOperator)
        {
            var associationPath = PropertyNameHelper.ResolvePropertyName(associationExpression);

            return
                new Criterion(
                    char.ToLowerInvariant(associationPath[0]) + associationPath.Substring(1) + "." +
                    PropertyNameHelper.ResolvePropertyName(childExpression), value, CriteriaOperator.Equal);
        }
    }
}