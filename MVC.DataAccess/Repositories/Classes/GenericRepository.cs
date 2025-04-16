using Microsoft.EntityFrameworkCore;
using MVC.DataAccess.Data.Contexts;
using MVC.DataAccess.Models.DepartmentModel;
using MVC.DataAccess.Models.Shared;
using MVC.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MVC.DataAccess.Repositories.Classes
{
    public class GenericRepository<TEntity>(ApplicationDbContext dbContext) : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly ApplicationDbContext _dbContext = dbContext; // Dependency Injection
                                                                      // Ask Clr For Creating Object From ApplicationDbContext

        // Get all 
        public IEnumerable<TEntity> GetAll(bool WithTracking = false)
        {
            if (WithTracking)
                return _dbContext.Set<TEntity>()./*Where(E=>E.IsDeleted != true).*/ToList();
            else
                return _dbContext.Set<TEntity>()/*.Where(E=>E.IsDeleted != true)*/.AsNoTracking().ToList();
        }
        public IEnumerable<TResult> GetAll<TResult>(Expression<Func<TEntity, TResult>> Selector)
        {
            return _dbContext.Set<TEntity>().Where(E => E.IsDeleted != true)
                             .Select(Selector).ToList();
        }
        // Get by id
        public TEntity? GetById(int id) => _dbContext.Set<TEntity>().Find(id);
        // Update
        public int Update(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity); // Update Locally
            return _dbContext.SaveChanges();
        }
        // Delete
        public int Remove(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity); // Remove Locally
            return _dbContext.SaveChanges();
        }
        // Insert
        public int Add(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity); // Add Locally
            return _dbContext.SaveChanges();
        }

        //public IEnumerable<TEntity> GetIEnumerable()
        //{
        //    return _dbContext.Set<TEntity>();
        //}

        //public IQueryable<TEntity> GetQueryable()
        //{
        //    return _dbContext.Set<TEntity>();
        //}
    }
}

