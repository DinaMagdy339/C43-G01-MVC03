using Microsoft.AspNetCore.Mvc;
using MVC.BusinessLogic.Services.Interfaces;
using MVC.DataAccess.Repositories.Interfaces;

namespace MVC.Presentation.Controllers
{
    public class EmployeesController (IEmployeeService _employeeService) : Controller
    {
        public IActionResult Index()
        {
            var Employees = _employeeService.GetAllEmployees();
            return View(Employees);
        }
    }
}
