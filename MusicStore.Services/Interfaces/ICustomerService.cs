#region Using Directives

using MusicStore.Services.Messaging.CustomerService;

#endregion

namespace MusicStore.Services.Interfaces
{
    public interface ICustomerService
    {
        GetCustomerResponse GetCustomer(GetCustomerRequest request);
    }
}