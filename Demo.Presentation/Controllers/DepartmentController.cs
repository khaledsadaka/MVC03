using Demo.BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Presentation.Controllers
{
    public class DepartmentsController(IDepartmentService _departmentServices) : Controller
    {
        // BaseURL/Departments/Index
        public IActionResult Index()
        
        {
            var departments = _departmentServices.GetAllDepartments();
            return View(departments);
        }



    }
}
