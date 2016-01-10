#region Using Directives

using System;
using MusicStore.Infrastructure.Domain;
using MusicStore.Model.Products;

#endregion

namespace MusicStore.Model.Ecommerce
{
    public class CartItem : EntityBase<CartItem, Guid>
    {
        private readonly Cart _cart;
        private readonly Album _album;
        private int _qty;

        public CartItem()
        {
        }

        public CartItem(Cart cart, Album album, int qty)
        {
            _cart = cart;
            _album = album;
            _qty = qty;
        }

        public virtual Cart Cart
        {
            get { return _cart; }
        }

        public virtual Album Album
        {
            get { return _album; }
        }

        public virtual int Qty
        {
            get { return _qty; }
        }

        public virtual bool Contains(Album album)
        {
            return Album == album;
        }

        public virtual void IncreaseItemQtyBy(int qty)
        {
            _qty += qty;
        }

        public virtual void ChangeItemQtyTo(int qty)
        {
            _qty = qty;
        }

        protected override void Validate()
        {
            if (Cart == null) { AddBrokenRule(CartItemBusinessRules.CartRequired); }

            if (Album == null) { AddBrokenRule(CartItemBusinessRules.AlbumRequired); }

            if (Qty < 0) { AddBrokenRule(CartItemBusinessRules.QtyInvalid); }
        }
    }
}