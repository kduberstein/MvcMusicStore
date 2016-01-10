#region Using Directives

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MusicStore.Services.ViewModels;

#endregion

namespace MusicStore.Controllers.ViewModels.Checkout
{
    public class AddressAndPaymentCheckoutViewModel
    {
        public Guid CustomerId { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "The 1st address line is required.")]
        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        [Required(ErrorMessage = "City is required.")]
        public string City { get; set; }

        [Required(ErrorMessage = "State is required.")]
        public string State { get; set; }

        public IEnumerable<StateView> StatesLookupList { get; set; }

        [Required(ErrorMessage = "Zip code is required.")]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "Promo code is required.")]
        public string PromoCode { get; set; }
    }
}