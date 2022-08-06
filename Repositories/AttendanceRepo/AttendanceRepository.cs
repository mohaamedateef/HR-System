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
        public List<Attendance> GetAll()
        {
            return context.Attendances.Include(n => n.Employee).ToList();
        }
        public Attendance GetById(int Id)
        {
            return context.Attendances.Include(a => a.Employee).FirstOrDefault(a => a.Id == Id);
        }
        public void AddAttendance(Attendance NewAttendance)
        {
            context.Attendances.Add(NewAttendance);
            context.SaveChanges();
        }
        public void UpdateAttendance(Attendance UpdatedAttendance, int Id)
        {
            UpdatedAttendance.Id = Id;
            context.Attendances.Update(UpdatedAttendance);
            context.SaveChanges();
        }
        public int? GetAttendanceOfDate(int id , DateTime Date)
        {
            int? SerachAttendanceId = context.Attendances.Where(a => a.EmpId == id && a.Date == Date).Select(a=>a.Id).FirstOrDefault();
            return SerachAttendanceId;
        }
        public void DeleteAttendance(int id)
        {
            context.Attendances.Remove(GetById(id));
            context.SaveChanges();
        }
    }
}
