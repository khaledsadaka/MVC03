using Demo.BusinessLogic.DataTransferObjects;
using Demo.BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Presentation.Controllers
{
    public class DepartmentsController(IDepartmentService _departmentServices,
       ILogger<DepartmentsController> _logger, IWebHostEnvironment _environment) : Controller
    {
        // BaseURL/Departments/Index
        public IActionResult Index()

        {
            var departments = _departmentServices.GetAllDepartments();
            return View(departments);
        }

        #region Create Department

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(CreatedDepartmentDto departmentDto) // Server Side Validation
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int Result = _departmentServices.AddDepartment(departmentDto);
                    if (Result > 0)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Department Cann't Be Created");
                    }
                }
                catch (Exception ex)
                {
                    if (_environment.IsDevelopment())
                    {
                        //1. Development => Log Error In Console And Return Same View With Error Message
                        ModelState.AddModelError(string.Empty, ex.Message);
                    }
                    else
                    {
                        //2. Deployment => Log Error In File | Table In Database And Return Error View
                        _logger.LogError(ex.Message);
                    }
                }

            }

            return View(departmentDto);



        }


        #endregion


    }
}
