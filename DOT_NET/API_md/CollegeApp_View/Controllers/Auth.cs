using Microsoft.AspNetCore.Mvc;

namespace EmployeeRepository_View.Controllers
{
    public class Auth : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
