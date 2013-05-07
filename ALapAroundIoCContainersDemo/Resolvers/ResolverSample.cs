using ALapAroundIoCContainersDemo.Components;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;
using NUnit.Framework;

namespace ALapAroundIoCContainersDemo.Resolvers
{
    [TestFixture]
    public class ResolverSample
    {
        [Test]
        public void UsingCollectionResolver()
        {
            IWindsorContainer container = new WindsorContainer();
            container.Kernel.Resolver.AddSubResolver(new CollectionResolver(container.Kernel));

            container.Register(
                Component.For<IRegistrationNotifier>().ImplementedBy<EmailNotifier>(),
                Component.For<IRegistrationNotifier>().ImplementedBy<SmsNotifier>(),
                Component.For<IRepository<Client>>().ImplementedBy<ClientRepository>(),
                Component.For<RegistrationService>());

            var registrationService = container.Resolve<RegistrationService>();
            registrationService.Register(new RegistrationData());
        }

        [Test]
        public void UsingFilteredCollectionResolver()
        {
            IWindsorContainer container = new WindsorContainer();
            container.Kernel.Resolver.AddSubResolver(new CollectionResolver(container.Kernel));

            container.Register(
                Component.For<IRegistrationNotifier>().ImplementedBy<EmailNotifier>().Named("EmailNotifier"),
                Component.For<IRegistrationNotifier>().ImplementedBy<SmsNotifier>(),
                Component.For<IRepository<Client>>().ImplementedBy<ClientRepository>(),
                Component.For<RegistrationService>().DependsOn(Dependency.OnComponentCollection("notifiers", "EmailNotifier")));

            var registrationService = container.Resolve<RegistrationService>();
            registrationService.Register(new RegistrationData());
        }
    }
}