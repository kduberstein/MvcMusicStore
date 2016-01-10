#region Using Directives

using System.Text.RegularExpressions;

#endregion

namespace MusicStore.Infrastructure.Helpers
{
    public static class PriceHelper
    {
        public static string FormatMoney(this decimal price)
        {
            return string.Format("{0:C}", price);
        }

        public static decimal UnFormatMoney(this string source)
        {
            var price = Regex.Replace(source, @"\s+", string.Empty);

            return decimal.Parse(Regex.Replace(price, @"[^0-9.]", string.Empty));
        }
    }
}