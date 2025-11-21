using Microsoft.AspNetCore.Mvc;

namespace AMI_Frontend01.Controllers
{
    public class ConsumerController : Controller
    {
        
        public IActionResult ConsumerData()
        {
            return View();
        }

        
        public IActionResult MyProfile()
        {
            return View();
        }
    }
}
