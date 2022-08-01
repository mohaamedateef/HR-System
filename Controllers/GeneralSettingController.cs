using Microsoft.AspNetCore.Mvc;

namespace HRSystem.Controllers
{
    public class GeneralSettingController : Controller
    {
        private readonly IGeneralSettingService GeneralService;
        public GeneralSettingController(IGeneralSettingService GeneralService)
        {
            this.GeneralService = GeneralService;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
