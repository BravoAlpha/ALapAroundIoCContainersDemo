using ALapAroundIoCContainersDemo.Components;
using ALapAroundIoCContainersDemo.InstallersAndConventions.Installers;
using Castle.Windsor;
using NUnit.Framework;

namespace ALapAroundIoCContainersDemo.InstallersAndConventions
{
    [TestFixture]
    public class InstallSamples
    {
        [Test]
        public void UsingInstall()
        {
            IWindsorContainer container = new WindsorContainer();
            container.Install(new ServicesInstaller(), 
                              new ViewModelsInstaller(),
                              new RepositoriesInstaller(),
                              new NotifiersInstaller());

            var clientRepository = container.Resolve<IRepository<Client>>();
            Assert.NotNull(clientRepository);
        }
    }
}