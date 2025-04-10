using MVC.BusinessLogic.DataTransferObjects;

namespace MVC.BusinessLogic.Services
{
    public interface IDepartmentService
    {
        int CreateDepartment(CreatedDepartmentDto departmentDto);
        IEnumerable<DepartmentDto> GetAllDepartments();
        DepartmentDetialsDto? GetDepartmentById(int id);
        bool RemoveDepartment(int id);
        int UpdateDepartment(UpdatedDepartmentDto departmentDto);
    }
}