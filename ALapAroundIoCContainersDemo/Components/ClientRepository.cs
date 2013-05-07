using System;
using System.ComponentModel;
using System.Diagnostics;

namespace ALapAroundIoCContainersDemo.Components
{
    [DebuggerDisplay("Id {_repositoryId}")]
    public class ClientRepository : IRepository<Client>, IDisposable, ISupportInitialize
    {
        private Guid _repositoryId;

        public ClientRepository()
        {
            _repositoryId = Guid.NewGuid();
        }

        public Client Get(int clientId)
        {
            // Gets the client from an internal cache
            return new Client();
        }

        public void Dispose()
        {
            // Do some clean up
        }

        public void BeginInit()
        {
            // Add initialization logic
        }

        public void EndInit()
        {
        }
    }
}