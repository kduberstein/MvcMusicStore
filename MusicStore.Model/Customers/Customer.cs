#region Using Directives

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MusicStore.Infrastructure.Domain;
using MusicStore.Model.Ecommerce;
using MusicStore.Model.Orders;

#endregion

namespace MusicStore.Model.Customers
{
    public class Customer : EntityBase<Customer, Guid>, IAggregateRoot
    {
        private readonly ISet<DeliveryAddress> _deliveryAddressBook = new HashSet<DeliveryAddress>();
        private readonly ISet<Order> _orders = new HashSet<Order>();

        public virtual UserLogin UserLogin { get; set; }

        public virtual string FirstName { get; set; }

        public virtual string LastName { get; set; }

        public virtual string EmailAddress { get; set; }

        public virtual string Phone { get; set; }

        public virtual IEnumerable<DeliveryAddress> DeliveryAddressBook
        {
            get { return _deliveryAddressBook; }
        }

        public virtual void AddAddress(DeliveryAddress deliveryAddress)
        {
            ThrowExceptionIfAddressIsInvalid(deliveryAddress);

            _deliveryAddressBook.Add(deliveryAddress);
        }

        public virtual IEnumerable<Order> Orders
        {
            get { return _orders; }
        }

        protected override void Validate()
        {
            if (UserLogin == null) { AddBrokenRule(CustomerBusinessRules.UserLoginRequired); }

            if (string.IsNullOrEmpty(FirstName)) { AddBrokenRule(CustomerBusinessRules.FirstNameRequired); }

            if (string.IsNullOrEmpty(LastName)) { AddBrokenRule(CustomerBusinessRules.LastNameRequired); }

            if (!new EmailValidationSpecification().IsSatisfiedBy(EmailAddress))
            {
                AddBrokenRule(CustomerBusinessRules.EmailAddressRequired);
            }
        }

        private static void ThrowExceptionIfAddressIsInvalid(DeliveryAddress deliveryAddress)
        {
            if (!deliveryAddress.GetBrokenRules().Any()) { return; }

            var deliveryAddressIssues = new StringBuilder();

            deliveryAddressIssues.AppendLine("There were some issues with the address you are adding.");

            foreach (var rule in deliveryAddress.GetBrokenRules())
            {
                deliveryAddressIssues.AppendLine(rule.Rule);
            }

            throw new InvalidAddressException(deliveryAddressIssues.ToString());
        }
    }
}