using ALapAroundIoCContainersDemo.Components;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using NUnit.Framework;

namespace ALapAroundIoCContainersDemo.Interceptors
{
    [TestFixture]
    public class InterceptorsSamples
    {
        [Test]
        public void UsingInterceptors()
        {
            IWindsorContainer container = new WindsorContainer();

            container.Register(
                Component.For<TimingInterceptor>().LifeStyle.Transient,
                Component.For<LoggingInterceptor>().LifeStyle.Transient,
                Component.For<IRepository<Client>>().ImplementedBy<ClientRepository>()
                         .Interceptors<LoggingInterceptor>()
                         .Interceptors<TimingInterceptor>());

            var repository = container.Resolve<IRepository<Client>>();
            repository.Get(2);
        }
    }
}