#region Using Directives

using System;
using MusicStore.Infrastructure.Domain;

#endregion

namespace MusicStore.Model.Products
{
    public class Genre : EntityBase<Genre, Guid>, IAggregateRoot
    {
        public virtual string Name { get; set; }

        public virtual string Description { get; set; }

        protected override void Validate()
        {
            if (string.IsNullOrEmpty(Name)) { AddBrokenRule(GenreBusinessRules.NameRequired); }

            if (string.IsNullOrEmpty(Description)) { AddBrokenRule(GenreBusinessRules.DescriptionRequired); }
        }
    }
}