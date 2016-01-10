#region Using Directives

using System.Web.Mvc;
using Castle.Facilities.Logging;
using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using MusicStore.Data.NHibernate;
using MusicStore.Data.NHibernate.Repositories;
using MusicStore.Data.NHibernate.SchemaCreation;
using MusicStore.Data.NHibernate.SessionStorage;
using MusicStore.Infrastructure.Authentication;
using MusicStore.Infrastructure.Configuration;
using MusicStore.Infrastructure.CookieStorage;
using MusicStore.Infrastructure.Domain.Events;
using MusicStore.Infrastructure.Email;
using MusicStore.Infrastructure.Encryption;
using MusicStore.Infrastructure.Logging;
using MusicStore.Infrastructure.SchemaCreation;
using MusicStore.Infrastructure.UnitOfWork;
using MusicStore.Model.Customers;
using MusicStore.Model.Ecommerce;
using MusicStore.Model.Orders;
using MusicStore.Model.Products;
using MusicStore.Model.Shared;
using MusicStore.Services.Implementations;
using MusicStore.Services.Interfaces;
using MusicStore.WebUI.Plumbing;

#endregion

namespace MusicStore.WebUI.Installers
{
    public class WindsorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            // Authentication
            container.Register(Component.For<IFormsAuthentication>().ImplementedBy<MvcFormsAuthentication>().LifestyleTransient());
            container.Register(Component.For<IMembershipValidator>().ImplementedBy<MembershipValidator>().LifestyleTransient());

            // AutoMapper
            Services.AutoMapperBootStrapper.ConfigureAutoMapper();
            Controllers.AutoMapperBootStrapper.ConfigureAutoMapper();

            // Configuration
            container.Register(Component.For<IApplicationSettings>().ImplementedBy<WebCfgApplicationSettings>().LifestyleTransient());

            // Controller Factory
            ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(container));

            // Controllers
            container.Register(
                Classes.FromAssemblyNamed("MusicStore.Controllers")
                    .BasedOn<IController>()
                    .If(c => c.Name.EndsWith("Controller"))
                    .LifestyleTransient());

            // Cookie Storage
            container.Register(Component.For<ICookieStorageService>().ImplementedBy<CookieStorageService>().LifestyleTransient());

            // Domain Event Plumbing
            container.AddFacility<TypedFactoryFacility>();
            container.Register(Component.For<AutoReleaseHandlerInterceptor>().LifestyleTransient());
            container.Register(Component.For<IDomainEventHandlerFactory>().AsFactory().LifestyleTransient());

            // Domain Events
            container.Register(
                Classes.FromAssemblyInThisApplication()
                    .BasedOn(typeof (IDomainEventHandler<>))
                    .WithServiceAllInterfaces()
                    .LifestyleTransient()
                    .Configure(c => c.Interceptors<AutoReleaseHandlerInterceptor>()));

            // Email
            container.Register(Component.For<ISmtpClient>().ImplementedBy<SmtpClientWrapper>().LifestyleTransient());
            container.Register(Component.For<IEmailService>().ImplementedBy<SmtpEmailService>().LifestyleTransient());

            // Encryption
            container.Register(Component.For<IEncryptor>().ImplementedBy<Encryptor>().LifestyleTransient());

            // Logging
            container.Register(Component.For<ILocalLogger>().ImplementedBy<Log4NetAdapter>().LifestyleTransient());

            // Logging Factory
            container.AddFacility<LoggingFacility>(f => f.UseLog4Net());

            // Repositories
            container.Register(Component.For<IGenreRepository>().ImplementedBy<GenreRepository>().LifestyleTransient());
            container.Register(Component.For<IArtistRepository>().ImplementedBy<ArtistRepository>().LifestyleTransient());
            container.Register(Component.For<IAlbumRepository>().ImplementedBy<AlbumRepository>().LifestyleTransient());
            container.Register(Component.For<ICartRepository>().ImplementedBy<CartRepository>().LifestyleTransient());
            container.Register(Component.For<IUserLoginRepository>().ImplementedBy<UserLoginRepository>().LifestyleTransient());
            container.Register(Component.For<ICustomerRepository>().ImplementedBy<CustomerRepository>().LifestyleTransient());
            container.Register(Component.For<IStateRepository>().ImplementedBy<StateRepository>().LifestyleTransient());
            container.Register(Component.For<IOrderRepository>().ImplementedBy<OrderRepository>().LifestyleTransient());
            container.Register(Component.For<INextSequenceRepository>().ImplementedBy<NextSequenceRepository>().LifestyleTransient());

            // Schema Creation
            container.Register(Component.For<ISchemaCreator>().ImplementedBy<SchemaCreator>().LifestyleTransient());

            // Services
            container.Register(Component.For<IGenreService>().ImplementedBy<GenreService>().LifestyleTransient());
            container.Register(Component.For<IArtistService>().ImplementedBy<ArtistService>().LifestyleTransient());
            container.Register(Component.For<IAlbumService>().ImplementedBy<AlbumService>().LifestyleTransient());
            container.Register(Component.For<IStoreService>().ImplementedBy<StoreService>().LifestyleTransient());
            container.Register(Component.For<ICartService>().ImplementedBy<CartService>().LifestyleTransient());
            container.Register(Component.For<IMembershipService>().ImplementedBy<MembershipService>().LifestyleTransient());
            container.Register(Component.For<ICustomerService>().ImplementedBy<CustomerService>().LifestyleTransient());
            container.Register(Component.For<IOrderService>().ImplementedBy<OrderService>().LifestyleTransient());

            // Session Storage
            container.Register(Component.For<IConfigurationBuilder>().ImplementedBy<ConfigurationBuilder>().LifestyleTransient());
            container.Register(Component.For<ISessionStorageFactory>().ImplementedBy<SessionStorageFactory>().LifestyleTransient());
            container.Register(Component.For<ISessionFactoryWrapper>().ImplementedBy<SessionFactory>().LifestyleTransient());
            container.Kernel.AddHandlerSelector(new StorageContainerSelector());
            container.Register(
                Component.For<ISessionStorageContainer>()
                    .ImplementedBy<HttpSessionContainer>()
                    .Named("HttpSessionContainer")
                    .LifestyleTransient());
            container.Register(
                Component.For<ISessionStorageContainer>()
                    .ImplementedBy<ThreadSessionContainer>()
                    .Named("ThreadSessionContainer")
                    .LifestyleTransient());

            // Unit of Work
            container.Register(Component.For<IUnitOfWork>().ImplementedBy<NhUnitOfWork>().LifestyleTransient());
        }
    }
}