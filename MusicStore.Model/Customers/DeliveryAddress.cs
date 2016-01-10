namespace MusicStore.Model.Customers
{
    public class DeliveryAddress : Address
    {
        public virtual Customer Customer { get; set; }

        public virtual string Name { get; set; }

        protected override void Validate()
        {
            if (Customer == null) { AddBrokenRule(DeliveryAddressBusinessRules.CustomerRequired); }

            if (string.IsNullOrEmpty(Name)) { AddBrokenRule(DeliveryAddressBusinessRules.NameRequired); }
        }
    }
}