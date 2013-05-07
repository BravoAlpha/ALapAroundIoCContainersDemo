using System;
using System.Linq;
using ALapAroundIoCContainersDemo.Components;
using Castle.MicroKernel;

namespace ALapAroundIoCContainersDemo.HandlerSelector
{
    public class DataAccessHandlerSelector : IHandlerSelector
    {
        bool _databaseIsDown;

        public DataAccessHandlerSelector()
        {
            DatabaseMonitor.OnChangedState += state => _databaseIsDown = state == DatabaseState.Down; ;
        }

        public bool HasOpinionAbout(string key, Type service)
        {
            return _databaseIsDown && service == typeof(IRepository<Client>);
        }

        public IHandler SelectHandler(string key, Type service, IHandler[] handlers)
        {
            return handlers.First(x => x.ComponentModel.Implementation == typeof(CachedClientRepository));
        }
    }
}