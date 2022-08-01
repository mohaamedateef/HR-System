using Microsoft.AspNetCore.Mvc;

namespace HRSystem.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
