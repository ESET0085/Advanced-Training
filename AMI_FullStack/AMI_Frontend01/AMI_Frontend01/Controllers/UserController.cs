using Microsoft.AspNetCore.Mvc;

namespace AMI_Frontend01.Controllers
{
    public class UserController : Controller
    {
        public IActionResult UserData()

        {
            return View();
        }
    }
}