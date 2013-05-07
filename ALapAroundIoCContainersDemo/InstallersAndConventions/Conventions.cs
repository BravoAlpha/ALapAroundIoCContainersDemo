using ALapAroundIoCContainersDemo.Components;
using Castle.Windsor;
using Castle.Windsor.Installer;
using NUnit.Framework;

namespace ALapAroundIoCContainersDemo.InstallersAndConventions
{
    [TestFixture]
    public class Conventions
    {
        [Test]
        public void ResolveNamedNotifiers()
        {
            IWindsorContainer container = new WindsorContainer();
            container.Install(FromAssembly.This());

            var emailNotifier = container.Resolve<IRegistrationNotifier>("EmailNotifier");
            var smsNotifier = container.Resolve<IRegistrationNotifier>("SmsNotifier");
        }

        [Test]
        public void ResolveRepositories()
        {
            IWindsorContainer container = new WindsorContainer();
            container.Install(FromAssembly.This());

            var clientRepository = container.Resolve<IRepository<Client>>();
            var courseRepository = container.Resolve<IRepository<Course>>();
        }
    }
}