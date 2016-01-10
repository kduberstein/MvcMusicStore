namespace MusicStore.Infrastructure.Email
{
    public interface ISmtpClient
    {
        void Send(string fromAddress, string toAddress, string subject, string body);
    }
}