#region Using Directives

using System;
using System.Linq;
using System.Web.Mvc;

#endregion

namespace MusicStore.Infrastructure.Authentication
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
    public class AuthorizationRoleAttribute : AuthorizeAttribute
    {
        public AuthorizationRoleAttribute(params object[] roles)
        {
            if (roles.Any(r => r.GetType().BaseType != typeof (Enum))) { throw new ArgumentException("roles"); }

            Roles = string.Join(",", roles.Select(r => Enum.GetName(r.GetType(), r)));
        }
    }
}