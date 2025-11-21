using Microsoft.AspNetCore.Mvc;

namespace AMI_Frontend01.Controllers
{
    public class MeterReadingController : Controller
    {
        public IActionResult MeterReadingData()

        {
            return View();
        }
    }
}