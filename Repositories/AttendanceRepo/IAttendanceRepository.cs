namespace HRSystem.Repositories.AttendanceRepo
{
    public interface IAttendanceRepository
    {

         List<Attendance> GetAllAttendences();
         Attendance GetAttendencyByEmpId(string Name);
         List<Attendance> SearcByDate(DateTime Date);
         void AddAttendence(Attendance newAttendence);
         void EditAttendence(int Id, Attendance newAttendence);
         void DeleteAttendence(int Id);
    }
}
