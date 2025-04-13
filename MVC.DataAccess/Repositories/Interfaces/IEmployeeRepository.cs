using MVC.DataAccess.Models.DepartmentModel;
using MVC.DataAccess.Models.EmployeeModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.DataAccess.Repositories.Interfaces
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
    }
}
