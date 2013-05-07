using ALapAroundIoCContainersDemo.Components;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using NUnit.Framework;

namespace ALapAroundIoCContainersDemo.LifeStyles
{
    [TestFixture]
    public class Pooled
    {
        [Test]
        public void ResolvingPooledComponentSample()
        {
            IWindsorContainer container = new WindsorContainer();

            container.Register(
                Component.For<IRepository<Client>>().ImplementedBy<ClientRepository>().LifeStyle.PooledWithSize(2, 4));

            // Two instances will be created when the component is first requested
            var instanceA = container.Resolve<IRepository<Client>>();
            var instanceB = container.Resolve<IRepository<Client>>();

            // The two instances will be marked as 'not in use' and will be available for subsequent requests
            container.Release(instanceA);
            container.Release(instanceB);

            // Same two instances will be returned
            var instanceC = container.Resolve<IRepository<Client>>();
            var instanceD = container.Resolve<IRepository<Client>>();

            // Two more instances will be created and added to the pool
            var instanceE = container.Resolve<IRepository<Client>>();
            var instanceF = container.Resolve<IRepository<Client>>();

            container.Dispose();
        }
    }
}