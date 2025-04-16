using Microsoft.AspNetCore.Mvc;
using MVC.BusinessLogic.DataTransferObjects;
using MVC.BusinessLogic.DataTransferObjects.DepartmentDtos;
using MVC.BusinessLogic.Services.Interfaces;
using MVC.Presentation.ViewModels.DepartmentViewModel;

namespace MVC.Presentation.Controllers
{
    public class DepartmentController(
        IDepartmentService _departmentService,
        ILogger<DepartmentController> _logger,
        IWebHostEnvironment _environment
    ) : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var departments = _departmentService.GetAllDepartments();
            return View(departments);
        }

        #region Create Department

        [HttpGet]
        //[ValidateAntiForgeryToken] // Action Filter

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(CreatedDepartmentDto departmentDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int result = _departmentService.CreateDepartment(departmentDto);
                    if (result > 0)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError("", "Failed to add department");
                    }
                }
                catch (Exception ex)
                {
                    if (_environment.IsDevelopment())
                    {
                        ModelState.AddModelError("", ex.Message);
                    }
                    else
                    {
                        _logger.LogError("Error occurred while adding department");
                    }
                }
            }
            return View(departmentDto);
        }
        #endregion

        #region Details of department

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest();
            }
            var department = _departmentService.GetDepartmentById(id.Value);
            if (department is null)
            {
                return NotFound();
            }
            return View(department);
        }
        #endregion

        #region Edit Department
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest();
            }
            var department = _departmentService.GetDepartmentById(id.Value);
            if (department is null)
            {
                return NotFound();
            }
            var departmentViewModel = new DepartmentEditViewModel()
            {
                Name = department.Name,
                Code = department.Code,
                Description = department.Description,
                DateOfCreation = department.DateOfCreation,
            };
            return View(departmentViewModel);
        }

        [HttpPost]
        public IActionResult Edit([FromRoute] int id, DepartmentEditViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var UpdatedDepartment = new UpdatedDepartmentDto()
                    {
                        Id = id,
                        Name = viewModel.Name,
                        Code = viewModel.Code,
                        Description = viewModel.Description,
                        DateOfCreation = viewModel.DateOfCreation,
                    };
                    int result = _departmentService.UpdateDepartment(UpdatedDepartment);
                    if (result > 0)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError("", "Failed to update department");
                    }
                }
                catch (Exception ex)
                {
                    if (_environment.IsDevelopment())
                    {
                        ModelState.AddModelError("", "Department is not Updated");
                    }
                    else
                    {
                        _logger.LogError("Error occurred while updating department");
                        return View("ErrorView", ex);
                    }
                }
            }

            return View(viewModel);
        }
        #endregion
        #region Delete Department
        //[HttpGet]
        //public IActionResult Delete(int? id)
        //{
        //    if (!id.HasValue)
        //    {
        //        return BadRequest();
        //    }
        //    var department = _departmentService.GetDepartmentById(id.Value);
        //    if (department is null)
        //    {
        //        return NotFound();
        //    }
        //    var departmentViewModel = new DepartmentEditViewModel()
        //    {
        //        Name = department.Name,
        //        Code = department.Code,
        //        Description = department.Description,
        //        DateOfCreation = department.DateOfCreation
        //    };
        //    return View(departmentViewModel);
        //}

        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            try
            {
                bool Deleted = _departmentService.RemoveDepartment(id);
                if (Deleted)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError("", "Failed to delete department");
                    return RedirectToAction(nameof(Delete), new { id });
                }
            }
            catch (Exception ex)
            {
                if (_environment.IsDevelopment())
                {
                    ModelState.AddModelError("", "Department is not Deleted");
                }
                else
                {
                    _logger.LogError("Error occurred while deleting department");
                    return View("ErrorView", ex);
                }
            }
            return View("ErrorView");
        }
        #endregion
    }
}
