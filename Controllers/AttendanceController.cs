using Microsoft.AspNetCore.Mvc;

namespace HRSystem.Controllers
{
    public class AttendanceController : Controller
    {
        IAttendanceRepository AttendenceRepo;



        public AttendanceController (IAttendanceRepository AttendRepo)
	{
            AttendenceRepo = AttendRepo;
	}




        public IActionResult ShowAllAttendces()
        {
            List<Attendence> AttendenceList = AttendenceRepo.GetAllAttendences();
            return View(AttendenceList);
        }


         public IActionResult ShowAttendcesByEmpId(int Id)
        {
            Attendance attendance = AttendenceRepo.GetAttendencyByEmpName(Id);
            return View(attendance);
        }



        public IActionResult ShowAttendenceByDate(DateTime Date)
        {
            List<Attendance> AttendenceList = AttendenceRepo.SearcByDate(Date);
        }


        public IActionResult AddingAttendence(Attendance newAttendence)
        {
            AttendenceRepo.AddAttendence(newAttendence);
            return RedirectToAction("ShowAllAttendces");  //This page will be generated from templates.
        }


        public IActionResult UpdatingAttendence(int Id, Attendance newAttendence)
        {
            AttendenceRepo.EditAttendence(Id, newAttendence);
            return RedirectToAction("ShowAllAttendces");
        }


        public void RemovingAttendence(int Id)
        {
            AttendenceRepo.DeleteAttendence(Id);
        }
    }
