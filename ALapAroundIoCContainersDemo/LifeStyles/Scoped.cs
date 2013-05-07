using ALapAroundIoCContainersDemo.Components;
using Castle.MicroKernel.Lifestyle;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using NUnit.Framework;

namespace ALapAroundIoCContainersDemo.LifeStyles
{
    [TestFixture]
    public class Scoped
    {
        [Test]
        public void ResolvingScopedComponents_ReturnsSameInstanceWithinTheScope()
        {
            IWindsorContainer container = new WindsorContainer();

            container.Register(
                Component.For<IRepository<Client>>().ImplementedBy<ClientRepository>().LifeStyle.Scoped());

            // IRepository<Client> can only be resolved within a scope
            using (container.BeginScope())
            {
                var instanceA = container.Resolve<IRepository<Client>>();
                var instanceB = container.Resolve<IRepository<Client>>();

                Assert.AreSame(instanceA, instanceB);
            }

            using (container.BeginScope())
            {
                var instanceC = container.Resolve<IRepository<Client>>();
            }

            container.Dispose();
        }
    }
}