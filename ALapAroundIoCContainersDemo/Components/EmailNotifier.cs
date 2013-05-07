using System;
using System.Diagnostics;

namespace ALapAroundIoCContainersDemo.Components
{
    [DebuggerDisplay("Id {_notifierId}")]
    public class EmailNotifier : IRegistrationNotifier
    {
        private readonly IRepository<Client> _clientRepository;
        private readonly Guid _notifierId;

        public EmailNotifier(IRepository<Client> clientRepository)
        {
            if (clientRepository == null)
                throw new ArgumentNullException("clientRepository", "clientRepository cannot be null");

            _clientRepository = clientRepository;
            _notifierId = Guid.NewGuid();
        }

        public void Notify(RegistrationData registrationData)
        {
            // Sends an email
        }
    }
}