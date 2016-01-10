#region Using Directives

using System;
using System.Collections.Generic;
using System.Security.Principal;

#endregion

namespace MusicStore.Infrastructure.Authentication.Principal
{
    public interface ICustomPrincipal : IPrincipal
    {
        Guid Id { get; set; }

        string FirstName { get; set; }

        string LastName { get; set; }

        string FullName { get; }

        IList<AuthorizationRole> AuthorizationRoles { get; set; }
    }
}