#region Using Directives

using System.Text.RegularExpressions;

#endregion

namespace MusicStore.Model.Customers
{
    public class EmailValidationSpecification
    {
        private static readonly Regex Emailregex = new Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");

        public bool IsSatisfiedBy(string email)
        {
            return Emailregex.IsMatch(email);
        }
    }
}