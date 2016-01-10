#region Using Directives

using System;
using MusicStore.Services.ViewModels;

#endregion

namespace MusicStore.Services.Messaging.MembershipService
{
    public class LoginUserResponse
    {
        public UserLoginView UserLogin { get; set; }

        public string CustomerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool HasIssues { get; set; }

        public string ErrorMessage { get; set; }
    }
}