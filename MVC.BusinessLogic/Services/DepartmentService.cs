using MVC.BusinessLogic.DataTransferObjects;
using MVC.BusinessLogic.Factories;
using MVC.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.BusinessLogic.Services
{
    public class DepartmentService(IDepartmentRepositery _departmentRepositery) : IDepartmentService
    {
        //Get All Departments
        public IEnumerable<DepartmentDto> GetAllDepartments()
        {
            var departments = _departmentRepositery.GetAll();
            return departments.Select(D => D.ToDepartmentDto());
        }
        //Get Department By Id
        public DepartmentDetialsDto? GetDepartmentById(int id)
        {
            var department = _departmentRepositery.GetById(id);
            return department is null ? null : department.ToDepartmentDetailsDto();
        }
        //Add Department
        public int AddDepartment(CreatedDepartmentDto departmentDto)
        {
            var department = departmentDto.ToEntity();
            return _departmentRepositery.Add(department);
        }
        //Update Department
        public int UpdateDepartment(UpdatedDepartmentDto departmentDto)
        {
            return _departmentRepositery.Update(departmentDto.ToEntity());
        }
        //Remove Department
        public bool RemoveDepartment(int id)
        {
            var department = _departmentRepositery.GetById(id);
            if (department is null) return false;
            else
            {
                int Result = _departmentRepositery.Remove(department);
                return Result > 0 ? true : false;
            }
        }
    }
}
