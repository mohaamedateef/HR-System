namespace HRSystem.Controllers
{
    //[Authorize(Roles = "Super Admin")]
    public class AttendanceController : Controller
    {
   
        public IActionResult Index()
        {
            return View();
        }
        
    }
}
