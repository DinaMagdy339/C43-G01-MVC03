using MVC.BusinessLogic.DataTransferObjects.EmployeeDtos;
using MVC.BusinessLogic.Services.Interfaces;
using MVC.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.BusinessLogic.Services.Classes
{
    public class EmployeeService(IEmployeeRepository _employeeRepositary) : IEmployeeService
    {
        public IEnumerable<EmployeeDto> GetAllEmployees(bool withTracking)
        {
            var employees = _employeeRepositary.GetAll(withTracking);
            return employees.Select(e => new EmployeeDto
            {
                Id = e.Id,
                Name = e.Name,
                Salary = e.Salary,
                IsActive = e.IsActive,
                Age = e.Age,
                Email = e.Email,
                EmployeeType = e.EmployeeType.ToString(),
                Gender = e.Gender.ToString()
            });
        }

        public EmployeeDetailsDto? GetEmployeeById(int id)
        {
           var employee = _employeeRepositary.GetById(id);
            return employee is null ? null: new EmployeeDetailsDto
            {
                Id = employee.Id,
                Name = employee.Name,
                Age = employee.Age,
                Email = employee.Email,
                Address = employee.Address,
                Salary = employee.Salary,
                IsActive = employee.IsActive,
                PhoneNumber = employee.PhoneNumber,
                HiringDate = DateOnly.FromDateTime(employee.HiringDate),
                EmployeeType = employee.EmployeeType.ToString(),
                Gender = employee.Gender.ToString(),
                CreatedBy = 1,
                CreatedOn = employee.CreatedOn,
                LastModifiedBy = 1,
                LastModifiedOn = employee.LastModifiedOn

            };
            
        }
        public int CreateEmployee(CreatedEmployeeDto employeeDto)
        {
            throw new NotImplementedException();
        }

        public bool DeleteEmployee(int id)
        {
            throw new NotImplementedException();
        }

        

        public int UpdateEmployee(UpdateedEmployeeDto employeeDto)
        {
            throw new NotImplementedException();
        }
    }
}
