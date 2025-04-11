using Microsoft.AspNetCore.Mvc;
using MVC.BusinessLogic.DataTransferObjects;
using MVC.BusinessLogic.Services;
using MVC.Presentation.ViewModels.DepartmentViewModel;

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

        #region Details of department

        [HttpGet]
        public IActionResult Details(int id)
        {
            if (id <= 0) return BadRequest();
            var department = _departmentService.GetDepartmentById(id);
            if (department is null) return NotFound();
            return View(department);
        }
        #endregion

        #region Edit Department
        [HttpGet]   
        public IActionResult Edit(int id)
        {
            if (id <= 0) return BadRequest();
            var department = _departmentService.GetDepartmentById(id);
            if (department is null) return NotFound();
            var departmentViewModel = new DepartmentEditViewModel
            {
                Name = department.Name,
                Code = department.Code,
                DateOfCreation = department.DateOfCreation,
                Description = department.Description
            };
            return View(departmentViewModel);
        }
        [HttpPost]
        public IActionResult Edit([FromRoute] int id, DepartmentEditViewModel ViewModel)
        {
            if (ModelState.IsValid) return View(ViewModel);
            {
                try
                {
                    var UpdatedDepartment = new UpdatedDepartmentDto
                    {
                        Id = id,
                        Name = ViewModel.Name,
                        Code = ViewModel.Code,
                        DateOfCreation = ViewModel.DateOfCreation,
                        Description = ViewModel.Description
                    };
                    int result = _departmentService.UpdateDepartment(UpdatedDepartment);
                    if (result > 0)
                        return RedirectToAction(nameof(Index));
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Department is not updated");
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
                        return View("ErrorView", ex);
                    }
                }
            }
            return View(ViewModel);
        }
        #endregion
        #region Delete Department
        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id <= 0) return BadRequest();
            var department = _departmentService.GetDepartmentById(id);
            if (department is null) return NotFound();
            return View(department);
        }
        [HttpPost]
        public IActionResult Delete(int id, IFormCollection form)
        {
            if (id == 0) return BadRequest();
            try
            {
                bool result = _departmentService.RemoveDepartment(id);
                if (result)
                    return RedirectToAction(nameof(Index));
                else
                {
                    ModelState.AddModelError(string.Empty, "Department is not deleted");
                    return RedirectToAction(nameof(Delete), new {id});
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
                    return View("ErrorView", ex);
                }
            }
            return View();
        }
        #endregion

    }
    }