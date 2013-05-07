namespace ALapAroundIoCContainersDemo.Components
{
    public interface IRepository<out T>
    {
        T Get(int id);
    }
}