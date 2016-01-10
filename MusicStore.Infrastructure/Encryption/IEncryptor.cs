namespace MusicStore.Infrastructure.Encryption
{
    public interface IEncryptor
    {
        string HashPassword(string password, int workFactor);

        string HashString(string input, int workFactor);

        bool Validate(string input, string correctHash);
    }
}