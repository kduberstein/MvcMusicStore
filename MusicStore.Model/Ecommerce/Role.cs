#region Using Directives

using System;
using MusicStore.Infrastructure.Domain;

#endregion

namespace MusicStore.Model.Ecommerce
{
    public class Role : EntityBase<Role, Guid>
    {
        public virtual UserLogin UserLogin { get; set; }

        public virtual string Name { get; set; }

        public virtual string Description { get; set; }

        protected override void Validate()
        {
            if (UserLogin == null) { AddBrokenRule(RoleBusinessRules.UserLoginRequired); }

            if (string.IsNullOrEmpty(Name)) { AddBrokenRule(RoleBusinessRules.NameRequired); }
        }
    }
}