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



        public Attendance GetAttendencyByEmpId(int Id)
        {
            Attendance attendance = context.Attendances.FirstOrDefault(x => x.EmpId == Id);
            return attendance;
        }



        public List<Attendance> SearcByDate(DateTime Date)
        {
            List<Attendance> attendances = context.Attendances.Where(x => x.Date ==Date).ToList();
            return attendances;
        }



        public void AddAttendence(Attendance newAttendence)
        {
            context.Attendances.Add(newAttendence);
            context.SaveChanges();
        }



        public void EditAttendence(int Id, Attendance newAttendence)
        {
            Attendance oldAttendence = context.Attendances.FirstOrDefault(x => x.Id==Id);
            oldAttendence.Date = newAttendence.Date;
            oldAttendence.Start = newAttendence.Start;
            oldAttendence.End = newAttendence.End;
            oldAttendence.Absent = newAttendence.Absent;
            oldAttendence.BonusHours = newAttendence.BonusHours;
            oldAttendence.DiscountHours = newAttendence.DiscountHours;
            context.SaveChanges();
        }



        public void DeleteAttendence(int Id)
        {
            Attendance attendence = context.Attendances.FirstOrDefault(x.Id ==Id);
            context.Attendances.Remove(attendence);
            context.SaveChanges();
        }
    }
}
