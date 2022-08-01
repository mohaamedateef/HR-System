using Microsoft.AspNetCore.Mvc;

namespace HRSystem.Controllers
{
    public class SalaryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
