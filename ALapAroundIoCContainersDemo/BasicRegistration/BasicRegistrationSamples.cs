using ALapAroundIoCContainersDemo.Components;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using NUnit.Framework;

namespace ALapAroundIoCContainersDemo.BasicRegistration
{
    [TestFixture]
    public class BasicRegistrationSamples
    {
        [Test]
        public void SimpleRegistration()
        {
            IWindsorContainer container = new WindsorContainer();

            container.Register(
                Component.For<IRepository<Client>>().ImplementedBy<ClientRepository>());

            var clientRepository = container.Resolve<IRepository<Client>>();
        }

        [Test]
        public void SelfServiceRegistration()
        {
            IWindsorContainer container = new WindsorContainer();

            container.Register(
                Component.For<ClientRepository>());

            var clientRepository = container.Resolve<ClientRepository>();

            // Will throw
            // var clientRepository = container.Resolve<IRepository<Client>>();
        }

        [Test]
        public void RegisteringMoreThanOneComponentForSameService_FirstComponentIsReturned()
        {
            IWindsorContainer container = new WindsorContainer();

            container.Register(
                Component.For<IRepository<Client>>().ImplementedBy<ClientRepository>(),
                Component.For<IRegistrationNotifier>().ImplementedBy<EmailNotifier>(),
                Component.For<IRegistrationNotifier>().ImplementedBy<SmsNotifier>());

            // Adding IsDefault() to SmsNotifier's registration will return it by default

            var notifier = container.Resolve<IRegistrationNotifier>();
            Assert.IsAssignableFrom<EmailNotifier>(notifier);
        }

        [Test]
        public void NamedRegistration()
        {
            IWindsorContainer container = new WindsorContainer();

            container.Register(
                Component.For<IRepository<Client>>().ImplementedBy<ClientRepository>(),
                Component.For<IRegistrationNotifier>().ImplementedBy<EmailNotifier>().Named("EmailNotifier"),
                Component.For<IRegistrationNotifier>().ImplementedBy<SmsNotifier>().Named("SmsNotifier"));

            // Will return EmailNotifier
            //var notifier = container.Resolve<IRegistrationNotifier>();

            var notifier = container.Resolve<IRegistrationNotifier>("SmsNotifier");
            Assert.IsAssignableFrom<SmsNotifier>(notifier);
        }

        [Test]
        public void MultipleServicesRegistration()
        {
            IWindsorContainer container = new WindsorContainer();

            container.Register(
                Component.For<IDataReader, IDataWriter>().ImplementedBy<DataManipulator>());

            var reader = container.Resolve<IDataReader>();
            var writer = container.Resolve<IDataWriter>();

            Assert.AreSame(reader, writer);
        }

        [Test]
        public void UsingDependsOn()
        {
            IWindsorContainer container = new WindsorContainer();

            container.Register(
                Component.For<IRepository<Client>>().ImplementedBy<ClientRepository>(),
                Component.For<IRegistrationNotifier>().ImplementedBy<EmailNotifier>().Named("EmailNotifier"),
                Component.For<IRegistrationNotifier>().ImplementedBy<SmsNotifier>().Named("SmsNotifier"),
                Component.For<RegistrationService>()
                         .DependsOn(Dependency.OnComponent("notifier", "SmsNotifier")));

            // Remove the DependsOn to fall back to the default component - EmailNotifier

            var registrationService = container.Resolve<RegistrationService>();
        }

        [Test]
        public void RegisteringStaticDependencies()
        {
            IWindsorContainer container = new WindsorContainer();

            container.Register(
                Component.For<IService>()
                    .ImplementedBy<ExpensiveService>()
                    .DependsOn(Dependency.OnValue("name", "moshe")));

            var service = container.Resolve<IService>();
        }
    }
}