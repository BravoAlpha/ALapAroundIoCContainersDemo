using ALapAroundIoCContainersDemo.Components;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace ALapAroundIoCContainersDemo.InstallersAndConventions.Installers
{
    public class RepositoriesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Classes.FromThisAssembly()
                       .BasedOn(typeof(IRepository<>))
                       .WithService.Base());
        }
    }
}