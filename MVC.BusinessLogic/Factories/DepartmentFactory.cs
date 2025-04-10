using MVC.BusinessLogic.DataTransferObjects;
using MVC.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.BusinessLogic.Factories
{
    static class DepartmentFactory
    {
        public static DepartmentDto ToDepartmentDto(this Department department)
        {
            return new DepartmentDto
            {
                DeptId = department.Id,
                Name = department.Name,
                Code = department.Code,
                Description = department.Description,
                DateOfCreation = DateOnly.FromDateTime(department.CreatedOn)
            };
        }
        public static DepartmentDetialsDto ToDepartmentDetailsDto(this Department department)
        {
            return new DepartmentDetialsDto
            {
                Id = department.Id,
                DateOfCreation = DateOnly.FromDateTime(department.CreatedOn),
                Name = department.Name,
                Code = department.Code,
                Description = department.Description
            };
        }
        public static Department ToEntity(this CreatedDepartmentDto departmentDto)
        {
            return new Department
            {
                Name = departmentDto.Name,
                Code = departmentDto.Code,
                Description = departmentDto.Description,
                CreatedOn = departmentDto.DateOfCreation.ToDateTime(new TimeOnly()),
            };
        }
        public static Department ToEntity(this UpdatedDepartmentDto departmentDto) => new Department
        {
            Id = departmentDto.Id,
            Name = departmentDto.Name,
            Code = departmentDto.Code,
            Description = departmentDto.Description,
            CreatedOn = departmentDto.DateOfCreation.ToDateTime(new TimeOnly()),

        };
    }
}
