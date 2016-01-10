#region Using Directives

using MusicStore.WebUI;
using WebActivatorEx;

#endregion

[assembly: PreApplicationStartMethod(typeof (WindsorActivator), "PreStart")]
[assembly: ApplicationShutdownMethod(typeof (WindsorActivator), "Shutdown")]

namespace MusicStore.WebUI
{
    public static class WindsorActivator
    {
        private static ContainerBootstrapper _bootstrapper;

        public static void PreStart()
        {
            _bootstrapper = ContainerBootstrapper.Bootstrap();
        }

        public static void Shutdown()
        {
            if (_bootstrapper != null) { _bootstrapper.Dispose(); }
        }
    }
}