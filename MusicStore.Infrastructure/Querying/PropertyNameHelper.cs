#region Using Directives

using System;
using System.Linq.Expressions;

#endregion

namespace MusicStore.Infrastructure.Querying
{
    public static class PropertyNameHelper
    {
        public static string ResolvePropertyName<T>(Expression<Func<T, object>> property)
        {
            var lambda = (LambdaExpression) property;

            MemberExpression memberExpression;

            var body = lambda.Body as UnaryExpression;

            if (body != null)
            {
                var unaryExpression = body;

                memberExpression = (MemberExpression) unaryExpression.Operand;
            }
            else
            {
                memberExpression = (MemberExpression) lambda.Body;
            }

            return memberExpression.Member.Name;
        }
    }
}