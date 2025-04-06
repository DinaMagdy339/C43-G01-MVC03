using MVC.DataAccess.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.DataAccess.Repositories
{
    internal class DepartmentRepositery(ApplicationDbContext dbContext)
    {
        private readonly ApplicationDbContext _dbContext = dbContext;

        // CRUD operations
        // Get all 
        // Get by id

        public Department GetById(int id)
        {
            var department = _dbContext.Departments.Find( id);
            return department;
        }


        // Update
        // Delete
        // Insert
    }
}
