#region Using Directives

using System;

#endregion

namespace MusicStore.Infrastructure.Logging
{
    public interface ILocalLogger
    {
        void LogInfo(string message);

        void LogError(string message, Exception exception);
    }
}