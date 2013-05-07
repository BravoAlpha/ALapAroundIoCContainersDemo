using ALapAroundIoCContainersDemo.Components;
using Castle.Windsor;
using Castle.Windsor.Installer;
using NUnit.Framework;

namespace ALapAroundIoCContainersDemo.InstallersAndConventions
{
    [TestFixture]
    public class FromAssemblySamples
    {
        [Test]
        public void UsingFromAssembly()
        {
            IWindsorContainer container = new WindsorContainer();
            container.Install(FromAssembly.This());

            var clientRepository = container.Resolve<IRepository<Client>>();
            Assert.NotNull(clientRepository);
        }
    }
}