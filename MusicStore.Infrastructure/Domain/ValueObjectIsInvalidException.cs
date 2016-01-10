#region Using Directives

using System;

#endregion

namespace MusicStore.Infrastructure.Domain
{
    public class ValueObjectIsInvalidException : Exception
    {
        public ValueObjectIsInvalidException(string message) : base(message)
        {
        }
    }
}