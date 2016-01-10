#region Using Directives

using MusicStore.Infrastructure.Domain;

#endregion

namespace MusicStore.Model.Customers
{
    public static class DeliveryAddressBusinessRules
    {
        public static readonly BusinessRule CustomerRequired
            = new BusinessRule("Customer", "A delivery address must be associated with a customer.");

        public static readonly BusinessRule NameRequired
            = new BusinessRule("Name", "A delivery address must have a name.");
    }
}