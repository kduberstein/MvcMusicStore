#region Using Directives

using System.Web;
using System.Web.Security;

#endregion

namespace MusicStore.Infrastructure.Authentication
{
    public class MvcFormsAuthentication : IFormsAuthentication
    {
        public void SetAuthenticationToken(string token, bool persistent)
        {
            FormsAuthentication.SetAuthCookie(token, persistent);
        }

        public string GetAuthenticationToken()
        {
            return HttpContext.Current.User.Identity.Name;
        }

        public string Encrypt(FormsAuthenticationTicket authTicket)
        {
            return FormsAuthentication.Encrypt(authTicket);
        }

        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }
    }
}