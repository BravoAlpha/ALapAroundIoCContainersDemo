using System.Threading.Tasks;
using ALapAroundIoCContainersDemo.Components;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using NUnit.Framework;

namespace ALapAroundIoCContainersDemo.LifeStyles
{
    [TestFixture]
    public class PerThread
    {
        [Test]
         public void ResolvingPerThreadComponents_NewInstanceIsCreatedForEachThread()
         {
             IWindsorContainer container = new WindsorContainer();

             container.Register(
                 Component.For<IRepository<Client>>().ImplementedBy<ClientRepository>().LifeStyle.PerThread);

             Task firstTask = Task.Factory.StartNew(() =>
             {
                 var repository = container.Resolve<IRepository<Client>>();
                 var secondRepository = container.Resolve<IRepository<Client>>();

                 Assert.AreSame(repository, secondRepository);
             });

             Task secondTask = Task.Factory.StartNew(() =>
             {
                 var repository = container.Resolve<IRepository<Client>>();
                 var secondRepository = container.Resolve<IRepository<Client>>();

                 Assert.AreSame(repository, secondRepository);
             });

             Task.WaitAll(firstTask, secondTask);

             container.Dispose();
         }
    }
}