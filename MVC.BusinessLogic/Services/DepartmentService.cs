using MVC.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.BusinessLogic.Services
{
    internal class DepartmentService
    {
        private readonly IDepartmentRepositery _departmentRepositery;
        public DepartmentService(IDepartmentRepositery departmentRepositery)    // 1- injection
        {
           this._departmentRepositery = departmentRepositery;
        }
    }
}
