using Microsoft.AspNetCore.Mvc;

namespace EmployeeRepository_View.Controllers
{
    public class Employee : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
