#region Using Directives

using System.Collections.Generic;

#endregion

namespace MusicStore.Infrastructure.Domain
{
    public abstract class EntityBase<T, TKey> : EqualityAndHashCodeProvider<T, TKey> where T : EqualityAndHashCodeProvider<T, TKey>
    {
        private readonly List<BusinessRule> _brokenRules = new List<BusinessRule>();

        protected int Version { get; set; }

        protected abstract void Validate();

        public virtual IEnumerable<BusinessRule> GetBrokenRules()
        {
            _brokenRules.Clear();

            Validate();

            return _brokenRules;
        }

        protected void AddBrokenRule(BusinessRule businessRule)
        {
            _brokenRules.Add(businessRule);
        }
    }
}