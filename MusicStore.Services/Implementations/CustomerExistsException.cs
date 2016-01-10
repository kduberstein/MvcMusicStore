#region Using Directives

using System;

#endregion

namespace MusicStore.Services.Implementations
{
    public class CustomerExistsException : Exception
    {
        public CustomerExistsException(string message) : base(message)
        {
        }
    }
}