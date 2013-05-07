using ALapAroundIoCContainersDemo.Components;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace ALapAroundIoCContainersDemo.InstallersAndConventions.Installers
{
    public class ServicesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<RegistrationService>().LifeStyle.Transient);
        }
    }
}