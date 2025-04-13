using Microsoft.AspNetCore.Mvc;
using MVC.BusinessLogic.DataTransferObjects.EmployeeDtos;
using MVC.BusinessLogic.Services.Interfaces;
using MVC.DataAccess.Repositories.Interfaces;

namespace MVC.Presentation.Controllers
{
    public class EmployeesController (IEmployeeService _employeeService , IWebHostEnvironment environment ,ILogger<EmployeesController> logger ) : Controller
    {
        public IActionResult Index()
        {
            var Employees = _employeeService.GetAllEmployees();
            return View(Employees);
        }
        [HttpGet]
        public IActionResult Create() => View();
        [HttpPost]
        public IActionResult Create(CreatedEmployeeDto employeeDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int Result = _employeeService.CreateEmployee(employeeDto);
                    if (Result > 0)
                        return RedirectToAction(nameof(Index));
                    else
                        ModelState.AddModelError(string.Empty, "Can’t create employee.");
                }
                catch(Exception ex)
                {
                    if(environment.IsDevelopment())
                       ModelState.AddModelError(string.Empty, ex.Message);
                    else
                        logger.LogError(ex.Message);
                }
            }
            return View(employeeDto);

        }
    }
}
