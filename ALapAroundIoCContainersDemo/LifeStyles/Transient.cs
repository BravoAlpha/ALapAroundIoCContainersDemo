using ALapAroundIoCContainersDemo.Components;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using NUnit.Framework;

namespace ALapAroundIoCContainersDemo.LifeStyles
{
    [TestFixture]
    public class Transient
    {
        [Test]
        public void ResolvingTransientComponents_ReturnsDifferentInstanceEachTime()
        {
            IWindsorContainer container = new WindsorContainer();

            container.Register(
                Component.For<IRepository<Client>>().ImplementedBy<ClientRepository>().LifeStyle.Transient);

            var instanceA = container.Resolve<IRepository<Client>>();
            var instanceB = container.Resolve<IRepository<Client>>();

            Assert.AreNotSame(instanceA, instanceB);

            container.Dispose();
        }
    }
}