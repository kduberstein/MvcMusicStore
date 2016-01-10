#region Using Directives

using System;
using System.Collections.Generic;
using MusicStore.Infrastructure.Domain;

#endregion

namespace MusicStore.Model.Ecommerce
{
    public class UserLogin : EntityBase<UserLogin, Guid>, IAggregateRoot
    {
        private readonly ISet<Role> _roles = new HashSet<Role>();

        public virtual string Username { get; set; }

        public virtual string Password { get; set; }

        public virtual bool IsAuthenticated { get; set; }

        public virtual IEnumerable<Role> Roles
        {
            get { return _roles; }
        }

        public virtual void Add(Role role)
        {
            if (_roles.Contains(role)) { return; }

            role.UserLogin = this;

            _roles.Add(role);
        }

        public virtual void Remove(Role role)
        {
            if (!_roles.Contains(role)) { return; }

            role.UserLogin = null;

            _roles.Remove(role);
        }

        protected override void Validate()
        {
            if (string.IsNullOrEmpty(Username)) { AddBrokenRule(UserLoginBusinessRules.UsernameRequired); }

            if (string.IsNullOrEmpty(Password)) { AddBrokenRule(UserLoginBusinessRules.PasswordRequired); }
        }
    }
}