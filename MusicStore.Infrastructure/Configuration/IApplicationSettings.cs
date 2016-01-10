namespace MusicStore.Infrastructure.Configuration
{
    public interface IApplicationSettings
    {
        int MinRequiredNonalphanumericCharacters { get; }

        int MinRequiredNumerals { get; }

        int MinRequiredPasswordLength { get; }

        string PasswordStrengthRegularExpression { get; }

        bool RequiresUniqueEmail { get; }
    }
}