using MVC.DataAccess.Data.Contexts;
using MVC.DataAccess.Models.DepartmentModel;
using MVC.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.DataAccess.Repositories.Classes
{
    // Primary Constructor
    public class DepartmentRepositery(ApplicationDbContext dbContext) :GenericRepository<Department>(dbContext) ,IDepartmentRepositery
    {
    }
}
