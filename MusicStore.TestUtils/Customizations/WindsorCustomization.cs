#region Using Directives

using System;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.Kernel;

#endregion

namespace MusicStore.TestUtils.Customizations
{
    public class WindsorCustomization : ICustomization
    {
        private readonly IWindsorContainer _container;

        public WindsorCustomization()
        {
            _container = new WindsorContainer().Install(FromAssembly.This());
        }

        public void Customize(IFixture fixture)
        {
            fixture.Customizations.Add(new WindsorAdapter(_container));
        }
    }

    public class WindsorAdapter : ISpecimenBuilder
    {
        private readonly IWindsorContainer _container;

        public WindsorAdapter(IWindsorContainer container)
        {
            _container = container;
        }

        public object Create(object request, ISpecimenContext context)
        {
            var t = request as Type;

            if (t == null || !_container.Kernel.HasComponent(t))
            {
                return new NoSpecimen();
            }

            return _container.Resolve(t);
        }
    }
}