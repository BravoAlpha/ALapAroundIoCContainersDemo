using System;
using System.Diagnostics;

namespace ALapAroundIoCContainersDemo.Components
{
    [DebuggerDisplay("Id {_name} {_id}")]
    public class ExpensiveService : IService, IDisposable
    {
        private readonly Guid _id;
        private readonly string _name;

        public ExpensiveService(string name)
        {
            _id = Guid.NewGuid();
            _name = name;
        }

        public void Perform()
        {
        }

        public void Dispose()
        {
            
        }
    }
}