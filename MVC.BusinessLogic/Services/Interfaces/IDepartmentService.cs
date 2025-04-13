using MVC.BusinessLogic.DataTransferObjects.DepartmentDtos;

namespace MVC.BusinessLogic.Services.Interfaces
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