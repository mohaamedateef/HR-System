using Microsoft.AspNetCore.Mvc;

namespace HRSystem.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
