#region Using Directives

using System;
using System.Collections.Generic;
using MusicStore.Infrastructure.Authentication;
using MusicStore.Services.ViewModels;

#endregion

namespace MusicStore.Services.Messaging.MembershipService
{
    public class RegisterUserResponse
    {
        public RegisterUserResponse()
        {
            AuthorizationRoles = new List<AuthorizationRole>();
        }

        public UserLoginView UserLogin { get; set; }

        public Guid CustomerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool HasIssues { get; set; }

        public string ErrorMessage { get; set; }

        public IList<AuthorizationRole> AuthorizationRoles { get; set; }
    }
}