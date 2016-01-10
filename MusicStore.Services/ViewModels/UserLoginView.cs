#region Using Directives

using System;

#endregion

namespace MusicStore.Services.ViewModels
{
    public class UserLoginView
    {
        public Guid Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public bool IsAuthenticated { get; set; }
    }
}