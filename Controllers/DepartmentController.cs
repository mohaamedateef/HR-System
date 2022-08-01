using Microsoft.AspNetCore.Mvc;

namespace HRSystem.Controllers
{
    public class DepartmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
