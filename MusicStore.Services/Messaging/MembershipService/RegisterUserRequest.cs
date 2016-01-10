#region Using Directives

using System.Collections.Generic;
using MusicStore.Infrastructure.Authentication;

#endregion

namespace MusicStore.Services.Messaging.MembershipService
{
    public class RegisterUserRequest
    {
        public RegisterUserRequest()
        {
            AuthorizationRoles = new List<AuthorizationRole>();
        }

        public string EmailAddress { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public IList<AuthorizationRole> AuthorizationRoles { get; set; }
    }
}