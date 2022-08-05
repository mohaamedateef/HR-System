using Microsoft.AspNetCore.Mvc;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace HRSystem.Controllers
{
    //[Authorize(Roles = "Super Admin")]
    public class AttendanceController : Controller
    {
        private readonly IAttendanceService AttendanceService;
        public AttendanceController(IAttendanceService AttendanceService)
        {
            this.AttendanceService = AttendanceService;
        }
        [HttpGet]
        public IActionResult Index(string Errors)
        {
            ViewBag.Errors = Errors;
            var EmployeeAttendances = AttendanceService.GetEmployeeAttendances();
            return View(EmployeeAttendances);
        }
        [HttpPost]
        public IActionResult AddFile(IFormFile File, [FromServices] IHostingEnvironment HostingEnviroment)
        {
            string FileName = $"{HostingEnviroment.WebRootPath}\\files\\{File.FileName}";
            using (FileStream FileStream = System.IO.File.Create(FileName))
            {
                File.CopyTo(FileStream);
                FileStream.Flush();
            }
            List<AttendanceExcelViewModel> ExcelData = AttendanceService.ReadDataFromExcelSheet(FileName);
            List<int> ListOfErrors = AttendanceService.AddAttendanceToDatabase(ExcelData);
            string txt;
            if (ListOfErrors.Count == 0)
            {
                txt = "Data Succefully Inserted.";
            }
            else
            {
                txt = "Attention!! \nThis Rows";
                for(int i = 0; i<ListOfErrors.Count;i++)
                {
                    txt += i+1;
                    txt += ", ";
                }
                txt += "have invalid data please check again.";
            }
            return RedirectToAction("Index", new { Errors = txt});
        }
    }
}
