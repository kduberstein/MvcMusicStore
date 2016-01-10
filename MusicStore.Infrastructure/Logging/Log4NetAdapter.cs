#region Using Directives

using System;
using Castle.Core.Logging;
using log4net.Config;

#endregion

namespace MusicStore.Infrastructure.Logging
{
    public class Log4NetAdapter : ILocalLogger
    {
        private readonly ILogger _log;

        public Log4NetAdapter(ILogger log)
        {
            _log = log;

            // Configure log4net.
            XmlConfigurator.Configure();
        }

        public void LogInfo(string message)
        {
            _log.Info(message);
        }

        public void LogError(string message, Exception exception)
        {
            _log.Error(message, exception);
        }
    }
}