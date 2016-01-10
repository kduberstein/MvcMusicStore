#region Using Directives

using System;
using System.Collections.Generic;
using System.Linq;
using MusicStore.Infrastructure.Domain;
using MusicStore.Model.Products;

#endregion

namespace MusicStore.Model.Ecommerce
{
    public class Cart : EntityBase<Cart, Guid>, IAggregateRoot
    {
        private readonly ISet<CartItem> _items = new HashSet<CartItem>();

        public virtual IEnumerable<CartItem> Items
        {
            get { return _items; }
        }

        public virtual void Add(Album album)
        {
            if (CartContainsAnItemFor(album))
            {
                GetItemFor(album).IncreaseItemQtyBy(1);
            }
            else
            {
                _items.Add(CartItemFactory.CreateItemFor(this, album));
            }
        }

        public virtual void Remove(Album album)
        {
            if (CartContainsAnItemFor(album))
            {
                _items.Remove(GetItemFor(album));
            }
        }

        public virtual CartItem GetItemFor(Album album)
        {
            return _items.FirstOrDefault(i => i.Contains(album));
        }

        public virtual decimal CartTotal
        {
            get { return _items.Sum(i => i.Qty * i.Album.Price); }
        }

        public virtual int NumberOfItems
        {
            get { return _items.Sum(i => i.Qty); }
        }

        public virtual void ChangeQtyOfAlbum(int qty, Album album)
        {
            if (CartContainsAnItemFor(album))
            {
                GetItemFor(album).ChangeItemQtyTo(qty);
            }
        }

        private bool CartContainsAnItemFor(Album album)
        {
            return _items.Any(i => i.Contains(album));
        }

        protected override void Validate()
        {
            foreach (var item in Items)
            {
                if (item.GetBrokenRules().Any())
                {
                    AddBrokenRule(CartBusinessRules.ItemInvalid);
                }
            }
        }
    }
}