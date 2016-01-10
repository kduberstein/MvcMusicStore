#region Using Directives

using System;
using System.Collections.Generic;

#endregion

namespace MusicStore.Services.ViewModels
{
    public class CustomerView
    {
        public Guid Id { get; set; }

        public UserLoginView UserLogin { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmailAddress { get; set; }

        public string Phone { get; set; }

        public IEnumerable<DeliveryAddressView> DeliveryAddressBook { get; set; } 

        public IEnumerable<OrderView> Orders { get; set; } 
    }
}