using HRSystem.Repositories.AttendanceRepo;

namespace HRSystem.Services.AttendanceServ
{
    public interface IAttendanceService : IAttendanceRepository
    {
        List<EmployeeAttendanceViewModel> GetEmployeeAttendances();
        List<AttendanceExcelViewModel> ReadDataFromExcelSheet(string FileName);
        List<int> AddAttendanceToDatabase(List<AttendanceExcelViewModel> AttendanceData);
    }
}
