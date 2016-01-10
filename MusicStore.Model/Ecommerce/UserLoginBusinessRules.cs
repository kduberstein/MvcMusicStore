#region Using Directives

using MusicStore.Infrastructure.Domain;

#endregion

namespace MusicStore.Model.Ecommerce
{
    public static class UserLoginBusinessRules
    {
        public static readonly BusinessRule UsernameRequired
            = new BusinessRule("Username", "A user login must have a username.");

        public static readonly BusinessRule PasswordRequired
            = new BusinessRule("Password", "A user login must have a password.");
    }
}