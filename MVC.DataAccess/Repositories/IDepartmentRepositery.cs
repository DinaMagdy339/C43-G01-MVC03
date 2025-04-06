
namespace MVC.DataAccess.Repositories
{
    public interface IDepartmentRepositery
    {
        int Add(Department department);
        IEnumerable<Department> GetAll(bool WithTracking = false);
        Department? GetById(int id);
        int Remove(Department department);
        int Update(Department department);
    }
}