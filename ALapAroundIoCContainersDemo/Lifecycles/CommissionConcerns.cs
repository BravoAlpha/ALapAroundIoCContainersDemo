using ALapAroundIoCContainersDemo.Components;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using NUnit.Framework;

namespace ALapAroundIoCContainersDemo.Lifecycles
{
    [TestFixture]
    public class CommissionConcerns
    {
        [Test]
        public void UsingOnCreate_OnCreateIsCalledWhenTheComponentIsResolved()
        {
            IWindsorContainer container = new WindsorContainer();

            bool wasCalled = false;

            container.Register(
                Component.For<IRepository<Client>>()
                         .ImplementedBy<ClientRepository>()
                         .OnCreate(component => wasCalled = true));

            // ClientRepository also implements ISupportInitialize,
            // Windsor will call BeginInit and EndInit when the component is created
            var repository = container.Resolve<IRepository<Client>>();

            Assert.IsTrue(wasCalled);
        }
    }
}