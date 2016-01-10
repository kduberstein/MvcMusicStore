#region Using Directives

using MusicStore.Infrastructure.Domain;

#endregion

namespace MusicStore.Model.Shared
{
    public class NextSequenceNumber : IAggregateRoot
    {
        public virtual string NextSequenceFormatted { get; set; }
    }
}