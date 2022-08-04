using Microsoft.AspNetCore.Mvc;

namespace HRSystem.Controllers
{
    public class ChatController : Controller
    {
        private readonly IAccountService accountService;

        public ChatController(IAccountService accountService)
        {
            this.accountService = accountService;
        }
        public IActionResult Index()
        {
            return View(accountService.GetAllUsersNames());
        }
    }
}
