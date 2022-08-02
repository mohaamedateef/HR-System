using HRSystem.Models;

namespace HRSystem.Repositories.AttendanceRepo
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly HRDbContext context;
        public AttendanceRepository(HRDbContext context)
        {
            this.context = context;
        }


        public List<Attendance> GetAllAttendences()
        {
            List<Attendance> attendances = context.Attendances.ToList();
            return attendances;
        }
    }
}
