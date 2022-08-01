using HRSystem.Repositories.AttendanceRepo;

namespace HRSystem.Services.AttendanceServ
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IAttendanceRepository AttendanceRepo;
        public AttendanceService(IAttendanceRepository AttendanceRepo)
        {
            this.AttendanceRepo = AttendanceRepo;
        }
    }
}
