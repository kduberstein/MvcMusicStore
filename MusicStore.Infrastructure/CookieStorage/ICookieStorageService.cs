#region Using Directives

using System;

#endregion

namespace MusicStore.Infrastructure.CookieStorage
{
    public interface ICookieStorageService
    {
        string Retrieve(string key);

        void Save(string key, string value, DateTime expires);
    }
}