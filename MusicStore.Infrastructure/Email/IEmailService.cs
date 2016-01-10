namespace MusicStore.Infrastructure.Email
{
    public interface IEmailService
    {
        void Send(string fromAddress, string toAddress, string subject, string body);
    }
}