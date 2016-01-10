#region Using Directives

using System;
using System.Web;

#endregion

namespace MusicStore.Infrastructure.CookieStorage
{
    public class CookieStorageService : ICookieStorageService
    {
        public string Retrieve(string key)
        {
            var cookie = HttpContext.Current.Request.Cookies[key];

            return cookie != null ? cookie.Value : string.Empty;
        }

        public void Save(string key, string value, DateTime expires)
        {
            var httpCookie = HttpContext.Current.Response.Cookies[key];

            if (httpCookie != null) { httpCookie.Value = value; }

            var cookie = HttpContext.Current.Response.Cookies[key];

            if (cookie != null) { cookie.Expires = expires; }
        }
    }
}