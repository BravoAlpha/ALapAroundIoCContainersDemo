using ALapAroundIoCContainersDemo.Components;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using NUnit.Framework;

namespace ALapAroundIoCContainersDemo.InstallersAndConventions
{
    [TestFixture]
    public class NoIstallersSample
    {
        [Test]
        public void NoInstallers()
        {
            IWindsorContainer container = new WindsorContainer();
            container.Register(
                Component.For<IRepository<Client>>().ImplementedBy<ClientRepository>(),
                Component.For<IRepository<Course>>().ImplementedBy<CourseRepository>(),
                Component.For<IRegistrationNotifier>().ImplementedBy<EmailNotifier>().Named("EmailNotifier"),
                Component.For<IRegistrationNotifier>().ImplementedBy<SmsNotifier>().Named("SmsNotifier"),
                Component.For<RegistrationService>().LifeStyle.Transient

                // And it goes on and on for each and every component in your application...
                );

            var clientRepository = container.Resolve<IRepository<Client>>();
            Assert.NotNull(clientRepository);
        }
    }
}