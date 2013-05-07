using ALapAroundIoCContainersDemo.Components;
using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using NUnit.Framework;

namespace ALapAroundIoCContainersDemo.TypedFactory
{
    [TestFixture]
    public class TypedFactorySamples
    {
        [Test]
        public void UsingDelegateBasedFactories()
        {
            IWindsorContainer container = new WindsorContainer();
            container.AddFacility<TypedFactoryFacility>();

            container.Register(
                Component.For<IService>().ImplementedBy<ExpensiveService>().LifeStyle.Transient,
                Component.For<ComponentWithDelegateBasedFactory>());

            var component = container.Resolve<ComponentWithDelegateBasedFactory>();
            component.DoSomething();
        }

        [Test]
        public void UsingInterfaceBasedFactories()
        {
            IWindsorContainer container = new WindsorContainer();
            container.AddFacility<TypedFactoryFacility>();

            container.Register(
                Component.For<IService>().ImplementedBy<ExpensiveService>().LifeStyle.Transient,
                Component.For<IServiceFactory>().AsFactory(),
                Component.For<ComponentWithInterfaceBasedFactory>());

            var component = container.Resolve<ComponentWithInterfaceBasedFactory>();
            component.DoSomething();
        }
    }
}