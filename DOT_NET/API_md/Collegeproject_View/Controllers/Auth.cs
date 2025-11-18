using Microsoft.AspNetCore.Mvc;

namespace Collegeproject_View.Controllers
{
    public class Auth : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
