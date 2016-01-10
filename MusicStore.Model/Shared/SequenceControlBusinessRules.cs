#region Using Directives

using MusicStore.Infrastructure.Domain;

#endregion

namespace MusicStore.Model.Shared
{
    public static class SequenceControlBusinessRules
    {
        public static readonly BusinessRule SequenceFormatRequired
            = new BusinessRule("SequenceFormat", "Sequence format is required.");
    }
}