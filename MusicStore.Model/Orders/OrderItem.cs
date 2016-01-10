#region Using Directives

using System;
using MusicStore.Infrastructure.Domain;
using MusicStore.Model.Products;

#endregion

namespace MusicStore.Model.Orders
{
    public class OrderItem : EntityBase<OrderItem, Guid>
    {
        private readonly Album _album;
        private readonly string _description;
        private readonly Order _order;
        private readonly decimal _price;
        private readonly int _qty;

        public OrderItem()
        {
        }

        public OrderItem(Album album, Order order, int qty, string description)
        {
            _album = album;
            _order = order;
            _qty = qty;
            _description = description;
            _price = album.Price;
        }

        public virtual Album Album
        {
            get { return _album; }
        }

        public virtual string Description
        {
            get { return _description; }
        }

        public virtual decimal LineTotal()
        {
            return Qty * Price;
        }

        public virtual Order Order
        {
            get { return _order; }
        }

        public virtual decimal Price
        {
            get { return _price; }
        }

        public virtual int Qty
        {
            get { return _qty; }
        }

        public virtual bool Contains(Album album)
        {
            return Album == album;
        }

        protected override void Validate()
        {
            if (Order == null) { AddBrokenRule(OrderItemBusinessRules.OrderRequired); }

            if (Album == null) { AddBrokenRule(OrderItemBusinessRules.AlbumRequired); }

            if (Qty < 0) { AddBrokenRule(OrderItemBusinessRules.QtyNonNegative); }

            if (string.IsNullOrEmpty(Description)) { AddBrokenRule(OrderItemBusinessRules.DescriptionRequired); }

            if (Price < 0) { AddBrokenRule(OrderItemBusinessRules.PriceNonNegative); }
        }
    }
}