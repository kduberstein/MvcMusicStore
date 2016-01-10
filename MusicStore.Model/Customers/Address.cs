#region Using Directives

using System;
using MusicStore.Infrastructure.Domain;

#endregion

namespace MusicStore.Model.Customers
{
    public class Address : EntityBase<Address, Guid>
    {
        public virtual string AddressLine1 { get; set; }

        public virtual string AddressLine2 { get; set; }

        public virtual string City { get; set; }

        public virtual string State { get; set; }

        public virtual string ZipCode { get; set; }

        protected override void Validate()
        {
            if (string.IsNullOrEmpty(AddressLine1)) { AddBrokenRule(AddressBusinessRules.AddressLine1Required); }

            if (string.IsNullOrEmpty(City)) { AddBrokenRule(AddressBusinessRules.CityRequired); }

            if (string.IsNullOrEmpty(State)) { AddBrokenRule(AddressBusinessRules.StateRequired); }

            if (string.IsNullOrEmpty(ZipCode)) { AddBrokenRule(AddressBusinessRules.ZipCodeRequired); }
        }
    }
}