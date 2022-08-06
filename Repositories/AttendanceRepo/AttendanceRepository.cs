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
        public List<EmployeeAttendanceViewModel> Search(SearchAttendanceViewModel viewModel)
        {
            List<Attendance> attendancesbyEmployee = context.Attendances.Include(n => n.Employee).Where(
                n => (n.Date >= viewModel.StartDate) ||
                   (n.Date <= viewModel.EndDate) &&
                   (n.Employee.Name.ToLower().Contains(viewModel.Name.ToLower()))).ToList();
            if (attendancesbyEmployee != null)
                return MappingAttendanceToEmpAttedVM(attendancesbyEmployee);
            List<Attendance> attendancesByDept = context.Attendances.Include(n => n.Employee).ThenInclude(n=>n.Department).Where(
                n => (n.Date >= viewModel.StartDate) ||
                   (n.Date <= viewModel.EndDate) &&
                   (n.Employee.Department.Name.ToLower().Contains(viewModel.Name.ToLower()))).ToList();
                return MappingAttendanceToEmpAttedVM(attendancesByDept);
        }
        public List<EmployeeAttendanceViewModel> MappingAttendanceToEmpAttedVM(List<Attendance> attendances)
        {
            List<EmployeeAttendanceViewModel> employeeAttendanceViewModels = new List<EmployeeAttendanceViewModel>();
            foreach (Attendance attendance  in attendances)
            {
                employeeAttendanceViewModels.Add(new EmployeeAttendanceViewModel { 
                    AttendanceId = attendance.Id,
                    CheckInTime = attendance.Start,
                    CheckOutTime = attendance.End,
                    EmployeeName = attendance.Employee.Name
                });
            }
            return employeeAttendanceViewModels;
        }
    }
}
