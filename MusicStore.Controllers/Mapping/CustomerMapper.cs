#region Using Directives

using AutoMapper;
using MusicStore.Controllers.ViewModels.Checkout;
using MusicStore.Services.Messaging.CustomerService;

#endregion

namespace MusicStore.Controllers.Mapping
{
    public static class CustomerMapper
    {
        public static AddressAndPaymentCheckoutViewModel ConvertToAddressAndPaymentCheckoutViewModel(this GetCustomerResponse response)
        {
            return Mapper.Map<GetCustomerResponse, AddressAndPaymentCheckoutViewModel>(response);
        }
    }
}