using Microsoft.AspNetCore.Mvc;

namespace HRSystem.Controllers
{
    public class WeeklyHolidayController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
