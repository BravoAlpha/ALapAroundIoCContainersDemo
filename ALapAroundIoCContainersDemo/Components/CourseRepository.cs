namespace ALapAroundIoCContainersDemo.Components
{
    public class CourseRepository : IRepository<Course>
    {
        public Course Get(int id)
        {
            return new Course();
        }
    }
}