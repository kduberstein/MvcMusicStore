#region Using Directives

using MusicStore.Infrastructure.Domain;

#endregion

namespace MusicStore.Model.Orders
{
    public static class OrderBusinessRules
    {
        public static readonly BusinessRule CustomerRequired =
           new BusinessRule("Customer", "An order must be associated with a customer.");

        public static readonly BusinessRule CreatedDateRequired
            = new BusinessRule("CreatedDate", "An order must have a created date.");

        public static readonly BusinessRule OrderNumberRequired
            = new BusinessRule("OrderNumber", "An order must have an order number.");

        public static readonly BusinessRule ItemsRequired 
            = new BusinessRule("Items", "An order must contain at least one order item.");
    }
}