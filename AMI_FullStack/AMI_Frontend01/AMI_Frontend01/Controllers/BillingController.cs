using Microsoft.AspNetCore.Mvc;

namespace AMI_Frontend01.Controllers
{
    public class BillingController : Controller
    {
        public IActionResult BillingData()

        {
            return View();
        }

        public IActionResult MyBills()
        {
            return View();
        }

    }
}
