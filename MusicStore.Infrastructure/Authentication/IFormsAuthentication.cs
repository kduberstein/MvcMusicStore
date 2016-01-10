#region Using Directives

using System.Web.Security;

#endregion

namespace MusicStore.Infrastructure.Authentication
{
    public interface IFormsAuthentication
    {
        void SetAuthenticationToken(string token, bool persistent);

        string GetAuthenticationToken();

        string Encrypt(FormsAuthenticationTicket authTicket);

        void SignOut();
    }
}