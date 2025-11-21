using Microsoft.AspNetCore.Mvc;

namespace AMI_Frontend01.Controllers
{
    public class TariffController : Controller
    {
        public IActionResult TariffData()

        {
            return View();
        }
    }
}