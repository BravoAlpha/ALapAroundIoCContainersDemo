namespace ALapAroundIoCContainersDemo.Components
{
    public class CachedClientRepository : IRepository<Client>
    {
        public Client Get(int id)
        {
            return new Client();
        }
    }
}