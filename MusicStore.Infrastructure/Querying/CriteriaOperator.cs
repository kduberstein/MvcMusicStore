#region Using Directives

using System;

#endregion

namespace MusicStore.Infrastructure.Querying
{
    public enum CriteriaOperator
    {
        Equal,
        LessThanOrEqual,
        [Obsolete("Do not use! Throws exception in query translator switch statement.")] NotApplicable
    }
}