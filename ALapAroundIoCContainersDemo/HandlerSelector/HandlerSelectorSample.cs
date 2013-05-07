using ALapAroundIoCContainersDemo.Components;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using NUnit.Framework;

namespace ALapAroundIoCContainersDemo.HandlerSelector
{
    // Based on a sample by Ayende http://ayende.com/blog/3633/windsor-ihandlerselector

    [TestFixture]
    public class HandlerSelectorSample
    {
        [Test] 
        public void UsingHandlerSelectors()
        {
            IWindsorContainer container = new WindsorContainer();
            container.Kernel.AddHandlerSelector(new DataAccessHandlerSelector());

            container.Register(
                Component.For<IRepository<Client>>().ImplementedBy<ClientRepository>(),
                Component.For<IRepository<Client>>().ImplementedBy<CachedClientRepository>());

            var clientRepository = container.Resolve<IRepository<Client>>();
            Assert.IsAssignableFrom<ClientRepository>(clientRepository);

            DatabaseMonitor.ReportFailure();

            var clientRepository2 = container.Resolve<IRepository<Client>>();
            Assert.IsAssignableFrom<CachedClientRepository>(clientRepository2);
        }
    }
}