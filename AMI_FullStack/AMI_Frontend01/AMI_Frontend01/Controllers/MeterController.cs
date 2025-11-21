using Microsoft.AspNetCore.Mvc;

namespace AMI_Frontend01.Controllers
{
    public class MeterController : Controller
    {
        public IActionResult MeterData()
          
        {
            return View();
        }

        public IActionResult MyMeters()

        {
            return View();
        }
    }
}
