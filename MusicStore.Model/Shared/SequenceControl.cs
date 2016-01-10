#region Using Directives

using MusicStore.Infrastructure.Domain;

#endregion

namespace MusicStore.Model.Shared
{
    public class SequenceControl : EntityBase<SequenceControl, string>
    {
        public virtual int LastSequence { get; set; }

        public virtual string SequenceFormat { get; set; }

        public virtual int ZeroPadToDigits { get; set; }

        public virtual int IncrementBy { get; set; }

        protected override void Validate()
        {
            if (string.IsNullOrEmpty(SequenceFormat))
            {
                AddBrokenRule(SequenceControlBusinessRules.SequenceFormatRequired);
            }
        }
    }
}