#region Using Directives

using System;
using System.Collections.Generic;
using System.Linq;
using MusicStore.Infrastructure.Domain;
using MusicStore.Model.Customers;
using MusicStore.Model.Products;

#endregion

namespace MusicStore.Model.Orders
{
    public class Order : EntityBase<Order, Guid>, IAggregateRoot
    {
        private readonly DateTime _created;
        private readonly ISet<OrderItem> _items = new HashSet<OrderItem>();

        public Order()
        {
            _created = DateTime.Now;
        }

        public virtual Customer Customer { get; set; }

        public virtual DateTime Created
        {
            get { return _created; }
        }

        public virtual string OrderNumber { get; set; }

        public virtual Address DeliveryAddress { get; set; }

        public virtual decimal Total()
        {
            return Items.Sum(i => i.LineTotal());
        }

        public virtual IEnumerable<OrderItem> Items
        {
            get { return _items; }
        }

        public virtual void AddItem(Album album, int qty, string description)
        {
            if (!OrderContains(album))
            {
                _items.Add(OrderItemFactory.CreateItemFor(album, this, qty, description));
            }
        }

        private bool OrderContains(Album album)
        {
            return _items.Any(i => i.Contains(album));
        }

        protected override void Validate()
        {
            if (Customer == null) { AddBrokenRule(OrderBusinessRules.CustomerRequired); }

            if (Created == DateTime.MinValue) { AddBrokenRule(OrderBusinessRules.CreatedDateRequired); }

            if (string.IsNullOrEmpty(OrderNumber)) { AddBrokenRule(OrderBusinessRules.OrderNumberRequired); }

            if (Items == null || !Items.Any())
            {
                AddBrokenRule(OrderBusinessRules.ItemsRequired);
            }
            else
            {
                if (!Items.Any(i => i.GetBrokenRules().Any())) { return; }

                foreach (var businessRule in Items.Where(i => i.GetBrokenRules().Any()).SelectMany(item => item.GetBrokenRules()))
                {
                    AddBrokenRule(businessRule);
                }
            }
        }
    }
}