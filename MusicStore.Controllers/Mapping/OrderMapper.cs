#region Using Directives

using AutoMapper;
using MusicStore.Controllers.ViewModels.Checkout;
using MusicStore.Services.Messaging.OrderService;

#endregion

namespace MusicStore.Controllers.Mapping
{
    public static class OrderMapper
    {
        public static CreateOrderRequest ConvertToCreateOrderRequest(this AddressAndPaymentCheckoutViewModel model)
        {
            return Mapper.Map<AddressAndPaymentCheckoutViewModel, CreateOrderRequest>(model);
        }
    }
}