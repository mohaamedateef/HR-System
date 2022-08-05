﻿namespace HRSystem.Repositories.AttendanceRepo
{
    public interface IAttendanceRepository
    {
        List<Attendance> GetAll();
        void AddAttendance(Attendance NewAttendance);
        int? GetAttendanceOfDate(int id, DateTime Date); 
        void UpdateAttendance(Attendance UpdatedAttendance,int Id);
        Attendance GetById(int Id);
    }
}
