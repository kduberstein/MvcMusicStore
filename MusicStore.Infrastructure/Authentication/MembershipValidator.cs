#region Using Directives

using System.Linq;
using System.Text.RegularExpressions;
using MusicStore.Infrastructure.Configuration;
using MusicStore.Infrastructure.Encryption;

#endregion

namespace MusicStore.Infrastructure.Authentication
{
    public class MembershipValidator : IMembershipValidator
    {
        private readonly IApplicationSettings _applicationSettings;
        private readonly IEncryptor _encryptor;
        private readonly string _passwordRegEx;
        private readonly bool _requiresUniqueEmail;

        public MembershipValidator(IApplicationSettings applicationSettings, IEncryptor encryptor)
        {
            _applicationSettings = applicationSettings;
            _encryptor = encryptor;
            _passwordRegEx = _applicationSettings.PasswordStrengthRegularExpression;
            _requiresUniqueEmail = _applicationSettings.RequiresUniqueEmail;
        }

        public bool IsValid(string emailAddress, string password, out string errorMessage)
        {
            if (!ValidateParameter(password, true, true, false, 128))
            {
                errorMessage = "Password is required and cannot exceed 128 characters";

                return false;
            }

            var hashedPassword = _encryptor.HashPassword(password, 8);

            if (hashedPassword.Length > 128)
            {
                errorMessage = "Hashed password length cannot be greater than 128 characters.";

                return false;
            }

            if (!ValidateParameter(emailAddress, _requiresUniqueEmail, _requiresUniqueEmail, false, 128))
            {
                errorMessage = "Email is required and cannot exceed 128 characters.";

                return false;
            }

            if (password.Length < _applicationSettings.MinRequiredPasswordLength)
            {
                errorMessage = string.Format("password must be at least {0} characters long.",
                    _applicationSettings.MinRequiredPasswordLength);

                return false;
            }

            var count = password.Where((t, i) => !char.IsLetterOrDigit(password, i)).Count();

            if (count < _applicationSettings.MinRequiredNonalphanumericCharacters)
            {
                errorMessage = string.Format("The password must contain {0} special characters.",
                    _applicationSettings.MinRequiredNonalphanumericCharacters);

                return false;
            }

            if (_passwordRegEx.Length > 0)
            {
                if (!IsMatch(password, _passwordRegEx))
                {
                    errorMessage =
                        string.Format(
                            "The passowrd does not match the password regular expression. " +
                            "The password must be at least {0} characters long, contain {1} number(s), and contain {2} special character(s) (!@#$&;*).",
                            _applicationSettings.MinRequiredPasswordLength, _applicationSettings.MinRequiredNumerals,
                            _applicationSettings.MinRequiredNonalphanumericCharacters);


                    return false;
                }
            }

            errorMessage = string.Empty;

            return true;
        }

        private static bool ValidateParameter(string param, bool checkForNull, bool checkIfEmpty, bool checkForCommas, int maxSize)
        {
            if (param == null) { return !checkForNull; }

            param = param.Trim();

            return (!checkIfEmpty || param.Length >= 1) && (maxSize <= 0 || param.Length <= maxSize) &&
                   (!checkForCommas || !param.Contains(","));
        }

        private static bool IsMatch(string stringToMatch, string pattern)
        {
            return Regex.IsMatch(stringToMatch, pattern);
        }
    }
}