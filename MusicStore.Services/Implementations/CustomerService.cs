#region Using Directives

using MusicStore.Model.Customers;
using MusicStore.Services.Interfaces;
using MusicStore.Services.Mapping;
using MusicStore.Services.Messaging.CustomerService;

#endregion

namespace MusicStore.Services.Implementations
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public GetCustomerResponse GetCustomer(GetCustomerRequest request)
        {
            var response = new GetCustomerResponse();

            var customer = _customerRepository.FindBy(request.Id);

            response.Customer = customer.ConvertToCustomerView();

            return response;
        }
    }
}