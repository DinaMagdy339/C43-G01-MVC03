using Microsoft.AspNetCore.Mvc;
using MVC.BusinessLogic.Services;

namespace MVC.Presentation.Controllers
{
    public class DepartmentController(IDepartmentService _departmentService) : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var departments = _departmentService.GetAllDepartments();
            return View(departments);
        }
    }
}
