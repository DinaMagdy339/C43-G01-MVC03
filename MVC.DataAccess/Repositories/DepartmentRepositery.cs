using MVC.DataAccess.Data.Contexts;
using MVC.DataAccess.Models.DepartmentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.DataAccess.Repositories
{
    // Primary Constructor
    public class DepartmentRepositery(ApplicationDbContext dbContext) : IDepartmentRepositery
    {
        private readonly ApplicationDbContext _dbContext = dbContext; // Dependency Injection
                                                                      // Ask Clr For Creating Object From ApplicationDbContext

        // Get all 
        public IEnumerable<Department> GetAll(bool WithTracking = false)
        {
            if (WithTracking)
            {
                return _dbContext.Departments.ToList();
            }
            else
            {
                return _dbContext.Departments.AsNoTracking().ToList();
            }
        }
        // Get by id
        public Department? GetById(int id) => _dbContext.Departments.Find(id);
        // Update
        public int Update(Department department)
        {
            _dbContext.Departments.Update(department); // Update Locally
            return _dbContext.SaveChanges();
        }
        // Delete
        public int Remove(Department department)
        {
            _dbContext.Departments.Remove(department); // Remove Locally
            return _dbContext.SaveChanges();
        }
        // Insert
        public int Add(Department department)
        {
            _dbContext.Departments.Add(department); // Add Locally
            return _dbContext.SaveChanges();
        }
    }
}
