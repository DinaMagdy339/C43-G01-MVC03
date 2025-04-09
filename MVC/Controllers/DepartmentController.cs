using Microsoft.AspNetCore.Mvc;
using MVC.BusinessLogic.DataTransferObjects;
using MVC.BusinessLogic.Services;

namespace MVC.Presentation.Controllers
{
    public class DepartmentController(IDepartmentService _departmentService , 
        ILogger<DepartmentController > _logger,
        IWebHostEnvironment _environment) : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var departments = _departmentService.GetAllDepartments();
            return View(departments);
        }

        #region Create Department

        [HttpGet]
        public IActionResult Create() => View();
        [HttpPost]
        public IActionResult Create(CreatedDepartmentDto departmentDto)
        {
            if (ModelState.IsValid) // server side validation
            {
                try
                {
                    int result = _departmentService.CreateDepartment(departmentDto);
                    if (result > 0)
                        return RedirectToAction(nameof(Index));
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Department can’t created");
                    }
                }
                catch (Exception ex)
                {
                    if (_environment.IsDevelopment())
                    {
                        ModelState.AddModelError(string.Empty, ex.Message);
                    }
                    else
                    {
                        _logger.LogError(ex.Message);
                    }
                }
            }
            return View(departmentDto);

        }

            #endregion

        }
    }