namespace MusicStore.Infrastructure.Authentication
{
    public interface IMembershipValidator
    {
        bool IsValid(string emailAddress, string password, out string errorMessage);
    }
}