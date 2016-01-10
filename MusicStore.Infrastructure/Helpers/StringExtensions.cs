namespace MusicStore.Infrastructure.Helpers
{
    public static class StringExtensions
    {
        public static string Truncate(this string value, int maxChars)
        {
            if (value == null) { return string.Empty; }

            return value.Length <= maxChars ? value : value.Substring(0, maxChars) + " ...";
        }
    }
}