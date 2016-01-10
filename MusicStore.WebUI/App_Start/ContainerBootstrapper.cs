#region Using Directives

using System;
using Castle.Windsor;
using Castle.Windsor.Installer;
using MvcSiteMapProvider;
using MvcSiteMapProvider.Loader;

#endregion

namespace MusicStore.WebUI
{
    public class ContainerBootstrapper : IContainerAccessor, IDisposable
    {
        private readonly IWindsorContainer _container;

        private ContainerBootstrapper(IWindsorContainer container)
        {
            _container = container;
        }

        public IWindsorContainer Container
        {
            get { return _container; }
        }

        public void Dispose()
        {
            Container.Dispose();
        }

        public static ContainerBootstrapper Bootstrap()
        {
            var container = new WindsorContainer().Install(FromAssembly.This());

            SiteMaps.Loader = container.Resolve<ISiteMapLoader>();

            return new ContainerBootstrapper(container);
        }
    }
}