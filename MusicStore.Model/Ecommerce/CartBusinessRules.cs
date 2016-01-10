#region Using Directives

using MusicStore.Infrastructure.Domain;

#endregion

namespace MusicStore.Model.Ecommerce
{
    public static class CartBusinessRules
    {
        public static readonly BusinessRule ItemInvalid
            = new BusinessRule("Item", "A cart cannot have any invalid items.");
    }
}