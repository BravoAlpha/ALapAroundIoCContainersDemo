using ALapAroundIoCContainersDemo.Components;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using NUnit.Framework;

namespace ALapAroundIoCContainersDemo.LifeStyles
{
    [TestFixture]
    public class Singleton
    {
        [Test]
        public void ResolvingSingletonComponents_ReturnsSameInstanceEveryTime()
        {
            IWindsorContainer container = new WindsorContainer();

            // Singleton is Windsor's default component lifestyle
            container.Register(
                Component.For<IRepository<Client>>().ImplementedBy<ClientRepository>());

            var instanceA = container.Resolve<IRepository<Client>>();
            var instanceB = container.Resolve<IRepository<Client>>();

            Assert.AreSame(instanceA, instanceB);

            container.Dispose();
        }
    }
}