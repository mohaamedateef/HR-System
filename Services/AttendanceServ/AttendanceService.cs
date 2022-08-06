using HRSystem.Models;
using HRSystem.Repositories.AttendanceRepo;
using System;

namespace HRSystem.Services.AttendanceServ
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IAttendanceRepository AttendanceRepo;
        private readonly IEmployeeService EmployeeService;
        private readonly IGeneralSettingService GeneralSetting;

        public AttendanceService(IAttendanceRepository AttendanceRepo,IEmployeeService EmployeeService, IGeneralSettingService GeneralSetting)
        {
            this.AttendanceRepo = AttendanceRepo;
            this.EmployeeService = EmployeeService;
            this.GeneralSetting = GeneralSetting;
        }
        public List<Attendance> GetAll()
        {
            return AttendanceRepo.GetAll();
        }
        public List<EmployeeAttendanceViewModel> GetEmployeeAttendances()
        {
            var EmployeeAttendances = new List<EmployeeAttendanceViewModel>();
            var Attendances = GetAll();
            foreach (var attendance in Attendances)
            {
                EmployeeAttendances.Add(new EmployeeAttendanceViewModel { AttendanceId = attendance.Id, EmployeeName = attendance.Employee.Name, CheckInTime = attendance.Start, CheckOutTime = attendance.End, Date = attendance.Date });
            }
            return EmployeeAttendances;
        }
        public List<AttendanceExcelViewModel> ReadDataFromExcelSheet(string FileName)
        {
            List<AttendanceExcelViewModel> ExcelData = new List<AttendanceExcelViewModel>();
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (var stream = System.IO.File.Open(FileName, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {

                    while (reader.Read()) //Each row of the file
                    {
                        if (reader.GetValue(0) == null)
                        {
                            break;
                        }
                        try
                        {
                            ExcelData.Add(new AttendanceExcelViewModel()
                            {
                                SSN = reader.GetValue(0).ToString().Trim(),
                                CheckInTime = reader.GetValue(1).ToString().Trim(),
                                CheckOutTime = reader.GetValue(2).ToString().Trim(),
                                Date = reader.GetValue(3).ToString().Trim()
                            });
                        }
                        catch (System.Exception ex)
                        {
                            throw new System.Exception("Excel Sheet Unformated Well.", ex);
                        }
                    }
                }
            }
            return ExcelData;
        }
        public List<int> AddAttendanceToDatabase(List<AttendanceExcelViewModel> AttendanceData)
        {
            AttendanceData.RemoveAt(0);
            List<int> UnformatedRows = new List<int>();
            List<Attendance> Attendances = new List<Attendance>();
            for (int i = 0; i < AttendanceData.Count; i++)
            {
                Employee employee = EmployeeService.GetEmployeeByNationalId(AttendanceData[i].SSN);
                if(employee == null)
                {
                    UnformatedRows.Add(i);
                    continue;
                }
                if (DateTime.Parse(AttendanceData[i].CheckInTime).TimeOfDay > DateTime.Parse(AttendanceData[i].CheckOutTime).TimeOfDay)
                {
                    UnformatedRows.Add(i);
                    continue;
                }
                if (DateTime.Compare(DateTime.Parse(AttendanceData[i].Date), DateTime.Now) > 0)
                {
                    UnformatedRows.Add(i);
                    continue;
                }
                Attendances.Add(new Attendance()
                {
                    EmpId = employee.Id,
                    Start = DateTime.Parse(AttendanceData[i].CheckInTime).TimeOfDay,
                    End = DateTime.Parse(AttendanceData[i].CheckOutTime).TimeOfDay,
                    Date = DateTime.Parse(AttendanceData[i].Date)
                }) ;
            }
            SaveChangesToDatabase(Attendances);
            return UnformatedRows;
        }
        public void SaveChangesToDatabase(List<Attendance> attendances)
        {
            int DiscountTime = 0;
            int BounsTime = 0;
            for (int i = 0; i < attendances.Count; i++)
            {
                Employee employee = EmployeeService.GetEmployeeById((int)attendances[i].EmpId);
                if (attendances[i].Start == attendances[i].End)
                {
                    attendances[i].Absent = true;
                }
                if (attendances[i].Start > employee.Start)
                {
                    TimeSpan Difference = attendances[i].Start - employee.Start;
                    int DifferenceMinutes = attendances[i].Start.Minutes;
                    if (DifferenceMinutes > 15)
                    {
                        DiscountTime = (int) Difference.TotalHours;
                        attendances[i].DiscountHours = DiscountTime+1;
                    }
                    else
                    {
                        DiscountTime = (int)Difference.TotalHours;
                        attendances[i].DiscountHours = DiscountTime;
                    }
                }
                if(attendances[i].End > employee.End)
                {
                    TimeSpan Difference = attendances[i].End - employee.End;
                    int DifferenceMinutes = attendances[i].End.Minutes;
                    if (DifferenceMinutes > 15)
                    {
                        BounsTime = (int)Difference.TotalHours;
                        attendances[i].BonusHours = BounsTime+1;
                    }
                    else
                    {
                        BounsTime = (int)Difference.TotalHours;
                        attendances[i].BonusHours = BounsTime;
                    }

                }
                int? AttendanceId = GetAttendanceOfDate(employee.Id, attendances[i].Date);
                if (AttendanceId != null)
                {
                    UpdateAttendance(attendances[i],(int)AttendanceId);
                }
                else
                {
                AddAttendance(attendances[i]);

                }
            }
        }
        public void AddAttendance(Attendance NewAttendance)
        {
            AttendanceRepo.AddAttendance(NewAttendance);
        }
        public int? GetAttendanceOfDate(int id, DateTime Date)
        {
            return AttendanceRepo.GetAttendanceOfDate(id, Date);
        }
        public void UpdateAttendance(Attendance UpdatedAttendance, int Id)
        {
            AttendanceRepo.UpdateAttendance(UpdatedAttendance, Id);
        }
        public Attendance GetById(int Id)
        {
            return AttendanceRepo.GetById(Id);
        }
        public void DeleteAttendance(int id)
        {
            AttendanceRepo.DeleteAttendance(id);
        }
        public void UpdateAttendanceViewModel(AttendanceEditViewModel UpdatedAttendance, int Id)
        {
            Attendance Attendance = GetById(Id);
            Attendance.Start = UpdatedAttendance.Start;
            Attendance.End = UpdatedAttendance.End;
            UpdateAttendance(Attendance, Id);
        }
        public List<string> GetExtensions()
        {
            return new List<string> { ".xlsx" , ".xls"};
        }
        public List<EmployeeAttendanceViewModel> Search(SearchAttendanceViewModel viewModel)
        {
            return AttendanceRepo.Search(viewModel);
        }
    }
}
