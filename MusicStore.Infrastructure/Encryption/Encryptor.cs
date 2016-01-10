namespace MusicStore.Infrastructure.Encryption
{
    public class Encryptor : IEncryptor
    {
        public string HashPassword(string password, int workFactor)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, GenerateSalt(workFactor));
        }

        public string HashString(string input, int workFactor)
        {
            return BCrypt.Net.BCrypt.HashString(input, workFactor);
        }

        public bool Validate(string input, string correctHash)
        {
            return BCrypt.Net.BCrypt.Verify(input, correctHash);
        }

        private static string GenerateSalt(int workFactor)
        {
            return BCrypt.Net.BCrypt.GenerateSalt(workFactor);
        }
    }
}