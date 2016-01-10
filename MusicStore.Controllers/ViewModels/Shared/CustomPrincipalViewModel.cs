#region Using Directives

using System;
using System.Collections.Generic;
using MusicStore.Infrastructure.Authentication;

#endregion

namespace MusicStore.Controllers.ViewModels.Shared
{
    public class CustomPrincipalViewModel
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public IList<AuthorizationRole> AuthorizationRoles { get; set; }
    }
}