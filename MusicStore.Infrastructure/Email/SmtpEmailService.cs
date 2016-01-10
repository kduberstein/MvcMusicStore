#region Using Directives

using System.Net.Mail;

#endregion

namespace MusicStore.Infrastructure.Email
{
    public class SmtpEmailService : IEmailService
    {
        private readonly ISmtpClient _smtpClient;

        public SmtpEmailService(ISmtpClient smtpClient)
        {
            _smtpClient = smtpClient;
        }

        public void Send(string fromAddress, string toAddress, string subject, string body)
        {
            var message = new MailMessage { From = new MailAddress(fromAddress) };

            message.To.Add(toAddress);
            message.Subject = subject;
            message.Body = body;

            _smtpClient.Send(fromAddress, toAddress, subject, body);
        }
    }
}