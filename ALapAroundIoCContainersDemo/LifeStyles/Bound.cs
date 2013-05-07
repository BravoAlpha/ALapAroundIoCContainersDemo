using ALapAroundIoCContainersDemo.Components;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using NUnit.Framework;

namespace ALapAroundIoCContainersDemo.LifeStyles
{
    [TestFixture]
    public class Bound
    {
        [Test]
        public void ResolvingBoundComponent_ReturnsSameInstance()
        {
            IWindsorContainer container = new WindsorContainer();

            container.Register(
                Component.For<IRegistrationNotifier>().ImplementedBy<EmailNotifier>().LifeStyle.Transient,
                Component.For<IRepository<Client>>().ImplementedBy<ClientRepository>().LifeStyle.BoundTo<RegistrationService>(),
                Component.For<RegistrationService>().LifeStyle.Transient);

            var registrationService = container.Resolve<RegistrationService>();
            var secondRegistrationService = container.Resolve<RegistrationService>();

            // Put a breakpoint and observe how each RegistrationService\EmailNotifer duo have their own ClientRepository instance.

            container.Dispose();
        }
    }
}