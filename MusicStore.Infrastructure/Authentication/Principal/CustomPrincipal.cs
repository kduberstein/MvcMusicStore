#region Using Directives

using System;
using System.Collections.Generic;
using System.Security.Principal;

#endregion

namespace MusicStore.Infrastructure.Authentication.Principal
{
    public class CustomPrincipal : ICustomPrincipal
    {
        public CustomPrincipal(string emailAddress)
        {
            Identity = new GenericIdentity(emailAddress);
        }

        public bool IsInRole(string role)
        {
            AuthorizationRole authorizationRole;

            Enum.TryParse(role, true, out authorizationRole);

            return AuthorizationRoles.Contains(authorizationRole);
        }

        public IIdentity Identity { get; private set; }

        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName
        {
            get { return string.Format("{0} {1}", FirstName, LastName); }
        }

        public IList<AuthorizationRole> AuthorizationRoles { get; set; }
    }
}