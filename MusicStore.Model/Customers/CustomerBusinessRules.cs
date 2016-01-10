#region Using Directives

using MusicStore.Infrastructure.Domain;

#endregion

namespace MusicStore.Model.Customers
{
    public static class CustomerBusinessRules
    {
        public static readonly BusinessRule UserLoginRequired
            = new BusinessRule("UserLogin", "A customer must have a user login.");

        public static readonly BusinessRule FirstNameRequired
            = new BusinessRule("FirstName", "A customer must have a first name.");

        public static readonly BusinessRule LastNameRequired
            = new BusinessRule("FirstName", "A customer must have a last name.");

        public static readonly BusinessRule EmailAddressRequired
            = new BusinessRule("EmailAddress", "A customer must have an email address.");
    }
}