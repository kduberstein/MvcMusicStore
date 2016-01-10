#region Using Directives

using System.Net.Mail;

#endregion

namespace MusicStore.Infrastructure.Email
{
    public class SmtpClientWrapper : SmtpClient, ISmtpClient
    {
    }
}