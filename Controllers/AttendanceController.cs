using Microsoft.AspNetCore.Mvc;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace HRSystem.Controllers
{
    //[Authorize(Roles = "Super Admin")]
    public class AttendanceController : Controller
    {
        private readonly IAttendanceService AttendanceService;
        private readonly IDepartmentService DepartmentService;

        public AttendanceController(IAttendanceService AttendanceService, IDepartmentService DepartmentService)
        {
            this.AttendanceService = AttendanceService;
            this.DepartmentService = DepartmentService;
        }
        [HttpGet]
        public IActionResult Index(string Errors)
        {
            var EmployeeAttendances = AttendanceService.GetEmployeeAttendances();
            ViewBag.Errors = Errors;
            ViewBag.Departments = DepartmentService.GetAll();
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
                for (int i = 0; i < ListOfErrors.Count; i++)
                {
                    txt += i + 1;
                    txt += ", ";
                }
                txt += "have invalid data please check again.";
            }
            return RedirectToAction("Index", new { Errors = txt });
        }
        [HttpGet]
        public IActionResult DeleteAttendance([FromRoute] int Id)
        {
            AttendanceService.DeleteAttendance(Id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            Attendance NewAttendacnce = AttendanceService.GetById(Id);
            AttendanceEditViewModel attendance = new AttendanceEditViewModel { Id = Id, Start = NewAttendacnce.Start, End = NewAttendacnce.End, Date = NewAttendacnce.Date, EmployeeName = NewAttendacnce.Employee.Name };
            return View(attendance);
        }
        [HttpPost]
        public IActionResult Edit(AttendanceEditViewModel attendance)
        {
            AttendanceService.UpdateAttendanceViewModel(attendance, attendance.Id);
            return RedirectToAction("Index");
        }
        public IActionResult CheckStart(TimeSpan Start, TimeSpan End)
        {
            if (Start > End)
            {
                return Json(false);
            }
            return Json(true);
        }
        public IActionResult CheckEnd(TimeSpan End, TimeSpan Start)
        {
            if (End > Start)
            {
                return Json(true);
            }
            return Json(false);
        }
    }
}