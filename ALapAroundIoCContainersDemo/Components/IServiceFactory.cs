namespace ALapAroundIoCContainersDemo.Components
{
    public interface IServiceFactory
    {
        IService Create(string name);
        void Release(IService service);
    }
}