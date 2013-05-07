using System.Collections.Generic;
using ALapAroundIoCContainersDemo.Components;

namespace ALapAroundIoCContainersDemo.Resolvers
{
    public class RegistrationService
    {
        private readonly IEnumerable<IRegistrationNotifier> _notifiers;

        public RegistrationService (IEnumerable<IRegistrationNotifier> notifiers)
        {
            _notifiers = notifiers;
        }

        public void Register(RegistrationData registrationData)
        {
            // Registration logic

            foreach(var notifier in _notifiers)
                notifier.Notify(registrationData);
        } 
    }
}