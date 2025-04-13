using Microsoft.EntityFrameworkCore;
using MVC.DataAccess.Data.Contexts;
using MVC.DataAccess.Models.EmployeeModel;
using MVC.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.DataAccess.Repositories.Classes
{
    public class EmployeeRepository(ApplicationDbContext dbContext) :GenericRepository<Employee>(dbContext) ,IEmployeeRepository
    {

    }
}
