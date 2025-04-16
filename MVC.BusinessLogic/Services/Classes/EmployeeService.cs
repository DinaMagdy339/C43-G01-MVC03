using AutoMapper;
using MVC.BusinessLogic.DataTransferObjects.EmployeeDtos;
using MVC.BusinessLogic.Services.Interfaces;
using MVC.DataAccess.Models.EmployeeModel;
using MVC.DataAccess.Repositories.Interfaces;

namespace MVC.BusinessLogic.Services.Classes
{
    public class EmployeeService(IEmployeeRepository _employeeRepositary , IMapper _mapper) : IEmployeeService
    {
        public IEnumerable<EmployeeDto> GetAllEmployees(bool withTracking = false)
        {
            //var Result = _employeeRepositary.GetIEnumerable()
            //                                .Where(E => E.IsDeleted != true)
            //                                .Select(E => new EmployeeDto
            //                                {
            //                                    Id = E.Id,
            //                                    Name = E.Name,
            //                                    Age = E.Age,
            //                                });
            //return Result.ToList();

            //var employees = _employeeRepositary.GetAll(withTracking);
            //var employeeDtos = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDto>>(employees);
            //return employeeDtos;

            var employeeDto = _employeeRepositary.GetAll(E => new EmployeeDto()
            {
                Id = E.Id,
                Name = E.Name,
                Salary = E.Salary,
                Age = E.Age,
            });
            return employeeDto.Where(E=>E.Age>25);
        }

        public EmployeeDetailsDto? GetEmployeeById(int id)
        {
           var employee = _employeeRepositary.GetById(id);
            return employee is null ? null: _mapper.Map<Employee, EmployeeDetailsDto>(employee);

        }
        public int CreateEmployee(CreatedEmployeeDto employeeDto)
        {
            var employee = _mapper.Map<CreatedEmployeeDto,Employee>(employeeDto);
            return _employeeRepositary.Add(employee);
        }
        public int UpdateEmployee(UpdatedEmployeeDto employeeDto)
        {
            return   _employeeRepositary.Update(_mapper.Map<UpdatedEmployeeDto, Employee>(employeeDto));
        }

        public bool DeleteEmployee(int id)
        {
            var employee = _employeeRepositary.GetById(id);
            if (employee is null)
            {
                return false;
            }
            else
            {
                employee.IsDeleted = true;
                return _employeeRepositary.Update(employee) > 0 ? true : false ;
            }
        }       
    }
}
