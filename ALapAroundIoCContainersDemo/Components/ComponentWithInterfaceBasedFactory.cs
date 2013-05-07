namespace ALapAroundIoCContainersDemo.Components
{
    public class ComponentWithInterfaceBasedFactory
    {
        private readonly IServiceFactory _serviceFactory;

        public ComponentWithInterfaceBasedFactory(IServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
        }

        public void DoSomething()
        {
            IService service = _serviceFactory.Create("First Service");
            IService service2 = _serviceFactory.Create("Second Service");

            service.Perform();
            service2.Perform();

            _serviceFactory.Release(service);
            _serviceFactory.Release(service2);
        }
    }
}