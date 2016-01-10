#region Using Directives

using System;
using System.Collections.Generic;
using System.Runtime.Caching;
using System.Web.Hosting;
using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using MusicStore.Services.ViewModels.NodeProviders;
using MvcSiteMapProvider;
using MvcSiteMapProvider.Builder;
using MvcSiteMapProvider.Caching;
using MvcSiteMapProvider.Security;
using MvcSiteMapProvider.Visitor;
using MvcSiteMapProvider.Web.Mvc;
using MvcSiteMapProvider.Web.UrlResolver;
using MvcSiteMapProvider.Xml;

#endregion

namespace MusicStore.WebUI.Installers
{
    public class MvcSiteMapProviderInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            const bool enableLocalization = true;
            var absoluteFileName = HostingEnvironment.MapPath("~/Sitemap/Mvc.sitemap");
            var absoluteCacheExpiration = TimeSpan.FromMinutes(5);
            const bool visibilityAffectsDescendants = true;
            const bool useTitleIfDescriptionNotProvided = true;
            const bool securityTrimmingEnabled = false;

            string[] includeAssembliesForScan = { "MusicStore.WebUI" };

            container.Kernel.Resolver.AddSubResolver(new ArrayResolver(container.Kernel, true));

            var currentAssembly = GetType().Assembly;

            var siteMapProviderAssembly = typeof (SiteMaps).Assembly;

            var dynamicNodeAssembly = typeof (GenreDynamicNodeProvider).Assembly;

            var allAssemblies = new[] { currentAssembly, siteMapProviderAssembly, dynamicNodeAssembly };

            var excludeTypes = new[] { typeof (SiteMapNodeUrlResolver) };

            var multipleImplementationTypes = new[]
            { typeof (ISiteMapNodeUrlResolver), typeof (ISiteMapNodeVisibilityProvider), typeof (IDynamicNodeProvider) };

            CommonConventions.RegisterDefaultConventions(
                (interfaceType, implementationType) =>
                    container.Register(Component.For(interfaceType).ImplementedBy(implementationType).LifestyleSingleton()),
                new[] { siteMapProviderAssembly }, allAssemblies, excludeTypes, string.Empty);

            CommonConventions.RegisterAllImplementationsOfInterface(
                (interfaceType, implementationType) =>
                    container.Register(Component.For(interfaceType).ImplementedBy(implementationType).LifestyleSingleton()),
                multipleImplementationTypes, allAssemblies, new Type[0], string.Empty);

            CommonConventions.RegisterAllImplementationsOfInterface(
                (interfaceType, implementationType) =>
                    container.Register(Component.For(implementationType).ImplementedBy(implementationType).LifestyleTransient()),
                new[] { typeof (IController) }, new[] { siteMapProviderAssembly }, new Type[0], string.Empty);

            container.Register(
                Component.For<ISiteMapNodeVisibilityProviderStrategy>()
                    .ImplementedBy<SiteMapNodeVisibilityProviderStrategy>()
                    .DependsOn(Dependency.OnValue("defaultProviderName", string.Empty)));

            container.Register(Component.For<ControllerBuilder>().Instance(ControllerBuilder.Current));

            container.Register(
                Component.For<IControllerTypeResolverFactory>()
                    .ImplementedBy<ControllerTypeResolverFactory>()
                    .DependsOn(Dependency.OnValue("areaNamespacesToIgnore", new string[0])));

            container.Register(
                Component.For<IAclModule>()
                    .ImplementedBy<CompositeAclModule>()
                    .DependsOn(Dependency.OnComponentCollection<IEnumerable<IAclModule>>(typeof (AuthorizeAttributeAclModule),
                        typeof (XmlRolesAclModule))));

            container.Register(Component.For<IAclModule>().ImplementedBy<AuthorizeAttributeAclModule>());

            container.Register(Component.For<IAclModule>().ImplementedBy<XmlRolesAclModule>());

            container.Register(Component.For<ObjectCache>().Instance(MemoryCache.Default));

            container.Register(Component.For(typeof (ICacheProvider<>)).ImplementedBy(typeof (RuntimeCacheProvider<>)));

            container.Register(
                Component.For<ICacheDependency>()
                    .ImplementedBy<RuntimeFileCacheDependency>()
                    .Named("cacheDependency1")
                    .DependsOn(Dependency.OnValue("fileName", absoluteFileName)));

            container.Register(
                Component.For<ICacheDetails>()
                    .ImplementedBy<CacheDetails>()
                    .Named("cacheDetails1")
                    .DependsOn(Dependency.OnValue("absoluteCacheExpiration", absoluteCacheExpiration))
                    .DependsOn(Dependency.OnValue("slidingCacheExpiration", TimeSpan.MinValue))
                    .DependsOn(ServiceOverride.ForKey<ICacheDependency>().Eq("cacheDependency1")));

            container.Register(Component.For<ISiteMapNodeVisitor>().ImplementedBy<UrlResolvingSiteMapNodeVisitor>());

            container.Register(
                Component.For<IXmlSource>()
                    .ImplementedBy<FileXmlSource>()
                    .Named("xmlSource1")
                    .DependsOn(Dependency.OnValue("fileName", absoluteFileName)));

            container.Register(
                Component.For<IReservedAttributeNameProvider>()
                    .ImplementedBy<ReservedAttributeNameProvider>()
                    .DependsOn(Dependency.OnValue("attributesToIgnore", new string[0])));

            container.Register(
                Component.For<ISiteMapNodeProvider>()
                    .ImplementedBy<CompositeSiteMapNodeProvider>()
                    .Named("siteMapNodeProvider1")
                    .DependsOn(Dependency.OnComponentCollection<ISiteMapNodeProvider[]>("xmlSiteMapNodeProvider1",
                        "reflectionSiteMapNodeProvider1")));

            container.Register(
                Component.For<ISiteMapNodeProvider>()
                    .ImplementedBy<XmlSiteMapNodeProvider>()
                    .Named("xmlSiteMapNodeProvider1")
                    .DependsOn(Dependency.OnValue("includeRootNode", true))
                    .DependsOn(Dependency.OnValue("useNestedDynamicNodeRecursion", false))
                    .DependsOn(ServiceOverride.ForKey<IXmlSource>().Eq("xmlSource1")));

            container.Register(
                Component.For<ISiteMapNodeProvider>()
                    .ImplementedBy<ReflectionSiteMapNodeProvider>()
                    .Named("reflectionSiteMapNodeProvider1")
                    .DependsOn(Dependency.OnValue("includeAssemblies", includeAssembliesForScan))
                    .DependsOn(Dependency.OnValue("excludeAssemblies", new string[0])));

            container.Register(
                Component.For<ISiteMapBuilder>()
                    .ImplementedBy<SiteMapBuilder>()
                    .Named("builder1")
                    .DependsOn(ServiceOverride.ForKey<ISiteMapNodeProvider>().Eq("siteMapNodeProvider1")));

            container.Register(
                Component.For<ISiteMapBuilderSet>()
                    .ImplementedBy<SiteMapBuilderSet>()
                    .Named("siteMapBuilderSet1")
                    .DependsOn(Dependency.OnValue("instanceName", "default"))
                    .DependsOn(Dependency.OnValue("securityTrimmingEnabled", securityTrimmingEnabled))
                    .DependsOn(Dependency.OnValue("enableLocalization", enableLocalization))
                    .DependsOn(Dependency.OnValue("visibilityAffectsDescendants", visibilityAffectsDescendants))
                    .DependsOn(Dependency.OnValue("useTitleIfDescriptionNotProvided", useTitleIfDescriptionNotProvided))
                    .DependsOn(ServiceOverride.ForKey<ISiteMapBuilder>().Eq("builder1"))
                    .DependsOn(ServiceOverride.ForKey<ICacheDetails>().Eq("cacheDetails1")));

            container.Register(
                Component.For<ISiteMapBuilderSetStrategy>()
                    .ImplementedBy<SiteMapBuilderSetStrategy>()
                    .DependsOn(Dependency.OnComponentCollection<ISiteMapBuilderSet[]>("siteMapBuilderSet1")));
        }
    }
}