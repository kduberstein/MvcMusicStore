#region Using Directives

using MusicStore.Infrastructure.Domain;

#endregion

namespace MusicStore.Model.Ecommerce
{
    public static class RoleBusinessRules
    {
        public static readonly BusinessRule UserLoginRequired
            = new BusinessRule("UserLogin", "A role must be associated with a user login.");

        public static readonly BusinessRule NameRequired
            = new BusinessRule("Name", "A role must have a name.");
    }
}