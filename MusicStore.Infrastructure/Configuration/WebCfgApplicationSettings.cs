#region Using Directives

using AuthenticationConfiguration;

#endregion

namespace MusicStore.Infrastructure.Configuration
{
    public class WebCfgApplicationSettings : IApplicationSettings
    {
        public int MinRequiredNonalphanumericCharacters
        {
            get { return AuthenticationCfg.Settings.MinRequiredNonalphanumericCharacters.Value; }
        }

        public int MinRequiredNumerals
        {
            get { return AuthenticationCfg.Settings.MinRequiredNumerals.Value; }
        }

        public int MinRequiredPasswordLength
        {
            get { return AuthenticationCfg.Settings.MinRequiredPasswordLength.Value; }
        }

        public string PasswordStrengthRegularExpression
        {
            get { return AuthenticationCfg.Settings.PasswordStrengthRegularExpression.Value; }
        }

        public bool RequiresUniqueEmail
        {
            get { return AuthenticationCfg.Settings.RequiresUniqueEmail.Value; }
        }
    }
}