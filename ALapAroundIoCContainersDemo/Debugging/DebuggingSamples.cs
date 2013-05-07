using ALapAroundIoCContainersDemo.Components;
using Castle.MicroKernel.Handlers;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using NUnit.Framework;

namespace ALapAroundIoCContainersDemo.Debugging
{
    [TestFixture]
    public class DebuggingSamples
    {
        [Test]
        [ExpectedException(typeof(HandlerException))]
        public void ViewingPotentiallyMisconfiguredComponents()
        {
            IWindsorContainer container = new WindsorContainer();
            container.Register(
                Component.For<IRegistrationNotifier>().ImplementedBy<EmailNotifier>());

            // Add a breakpoint here and watch the container's Potentially Misconfigured Components property
            var notifier = container.Resolve<IRegistrationNotifier>();
        }

        [Test]
        public void ViewingObjectsTrackedByReleasePolicy()
        {
            IWindsorContainer container = new WindsorContainer();
            container.Register(
                Component.For<IRepository<Client>>().ImplementedBy<ClientRepository>().LifeStyle.Transient,
                Component.For<IRegistrationNotifier>().ImplementedBy<EmailNotifier>().LifeStyle.Transient);

            // Add a breakpoint here and watch the container's Objects Tracked By Release Policy property
            var notifier = container.Resolve<IRegistrationNotifier>();
            container.Release(notifier);
        }
    }
}