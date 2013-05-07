using ALapAroundIoCContainersDemo.Components;
using Castle.MicroKernel.Lifestyle;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using NUnit.Framework;

namespace ALapAroundIoCContainersDemo.Lifecycles
{
    [TestFixture]
    public class DecommissionConcerns
    {
        [Test]
        public void UsingOnDistroyForTransientComponent_OnDestroyIsCalledWhenComponentIsReleased()
        {
            IWindsorContainer container = new WindsorContainer();

            bool wasCalled = false;

            container.Register(
                Component.For<IRepository<Client>>()
                         .ImplementedBy<ClientRepository>()
                         .LifeStyle.Transient
                         .OnDestroy(component => wasCalled = true));

            // ClientRepository also implements IDisposable,
            // Windsor will call Dispose when the component is released
            var repository = container.Resolve<IRepository<Client>>();
            container.Release(repository);

            Assert.IsTrue(wasCalled);
        }

        [Test]
        public void UsingOnDistroyForSingletonComponent_OnDestroyIsCalledWhenContainerIsDisposed()
        {
            IWindsorContainer container = new WindsorContainer();

            bool wasCalled = false;

            container.Register(
                Component.For<IRepository<Client>>()
                         .ImplementedBy<ClientRepository>()
                         .OnDestroy(component => wasCalled = true));

            var repository = container.Resolve<IRepository<Client>>();
            container.Release(repository);

            Assert.IsFalse(wasCalled);

            // ClientRepository also implements IDisposable,
            // Windsor will call Dispose when the component is released
            container.Dispose();

            Assert.IsTrue(wasCalled);
        }

        [Test]
        public void UsingOnDistroyForScopedComponent_OnDestroyIsCalledScopeIsDisposed()
        {
            IWindsorContainer container = new WindsorContainer();

            bool wasCalled = false;

            container.Register(
                Component.For<IRepository<Client>>()
                         .ImplementedBy<ClientRepository>()
                         .LifeStyle.Scoped()
                         .OnDestroy(component => wasCalled = true));

            using(container.BeginScope())
            {
                // ClientRepository also implements IDisposable,
                // Windsor will call Dispose when the component is released
                var repository = container.Resolve<IRepository<Client>>();
            }

            Assert.IsTrue(wasCalled);
        }
    }
}