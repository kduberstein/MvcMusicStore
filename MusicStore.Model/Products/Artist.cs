#region Using Directives

using System;
using MusicStore.Infrastructure.Domain;

#endregion

namespace MusicStore.Model.Products
{
    public class Artist : EntityBase<Artist, Guid>, IAggregateRoot
    {
        public virtual string Name { get; set; }

        protected override void Validate()
        {
            if (string.IsNullOrEmpty(Name)) { AddBrokenRule(ArtistBusinessRules.NameRequired); }
        }
    }
}