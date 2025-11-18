using Microsoft.AspNetCore.Mvc;

namespace Collegeproject_View.Controllers
{
    public class Student : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
