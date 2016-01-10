#region Using Directives

using AutoMapper;
using MusicStore.Model.Customers;
using MusicStore.Services.ViewModels;

#endregion

namespace MusicStore.Services.Mapping
{
    public static class CustomerMapper
    {
        public static CustomerView ConvertToCustomerView(this Customer customer)
        {
            return Mapper.Map<Customer, CustomerView>(customer);
        }
    }
}