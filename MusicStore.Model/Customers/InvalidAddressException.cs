#region Using Directives

using System;

#endregion

namespace MusicStore.Model.Customers
{
    public class InvalidAddressException : Exception
    {
        public InvalidAddressException(string message) : base(message)
        {
        }
    }
}