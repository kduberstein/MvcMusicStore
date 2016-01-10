#region Using Directives

using MusicStore.Services.ViewModels;

#endregion

namespace MusicStore.Services.Messaging.CustomerService
{
    public class GetCustomerResponse
    {
        public CustomerView Customer { get; set; }
    }
}