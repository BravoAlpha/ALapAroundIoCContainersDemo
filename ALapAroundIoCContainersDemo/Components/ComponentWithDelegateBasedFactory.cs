using System;

namespace ALapAroundIoCContainersDemo.Components
{
    public class ComponentWithDelegateBasedFactory
    {
        private readonly Func<string, IService> _serviceFactory;

        public ComponentWithDelegateBasedFactory (Func<string, IService> serviceFacotory)
        {
            _serviceFactory = serviceFacotory;
        }

        public void DoSomething()
        {
            IService service = _serviceFactory("First Service");
            service.Perform();

            // Components are released when the factory itself is released
        }
    }
}