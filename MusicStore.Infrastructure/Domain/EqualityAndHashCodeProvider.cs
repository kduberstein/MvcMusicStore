namespace MusicStore.Infrastructure.Domain
{
    public abstract class EqualityAndHashCodeProvider<T, TKey> where T : EqualityAndHashCodeProvider<T, TKey>
    {
        private int? _cachedHashCode;

        public virtual TKey Id { get; protected set; }

        protected bool IsTransient
        {
            get { return Equals(Id, default(TKey)); }
        }

        public override bool Equals(object obj)
        {
            return EntityEquals(obj as EqualityAndHashCodeProvider<T, TKey>);
        }

        protected bool EntityEquals(EqualityAndHashCodeProvider<T, TKey> other)
        {
            if (other == null || !GetType().IsInstanceOfType(other)) { return false; }

            // One entity is transient and the other is persistent.
            if (IsTransient ^ other.IsTransient) { return false; }

            // Neither entity is persisted.
            if (IsTransient && other.IsTransient) { return ReferenceEquals(this, other); }

            return other.Id.Equals(Id);
        }

        public override int GetHashCode()
        {
            if (_cachedHashCode.HasValue)
            {
                return _cachedHashCode.Value;
            }

            _cachedHashCode = IsTransient ? base.GetHashCode() : Id.GetHashCode();

            return _cachedHashCode.Value;
        }

        public static bool operator ==(EqualityAndHashCodeProvider<T, TKey> x, EqualityAndHashCodeProvider<T, TKey> y)
        {
            return Equals(x, y);
        }

        public static bool operator !=(EqualityAndHashCodeProvider<T, TKey> x, EqualityAndHashCodeProvider<T, TKey> y)
        {
            return !(x == y);
        }
    }
}