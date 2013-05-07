using System;

namespace ALapAroundIoCContainersDemo.Components
{
    public class RegistrationService
    {
        private readonly IRegistrationNotifier _notifier;
        private readonly IRepository<Client> _clientRepository;

        public RegistrationService(IRegistrationNotifier notifier, IRepository<Client> clientRepository)
        {
            if (notifier == null)
                throw new ArgumentNullException("notifier", "notifier cannot be null");

            if (clientRepository == null)
                throw new ArgumentNullException("clientRepository", "clientRepository cannot be null");

            _notifier = notifier;
            _clientRepository = clientRepository;
        }

        public void Register(RegistrationData registrationData)
        {
            Client client = _clientRepository.Get(registrationData.ClientId);

            // Registration logic

            _notifier.Notify(registrationData);
        } 
    }
}