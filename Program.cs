using HRSystem.Models;
using HRSystem.Repositories.AttendanceRepo;
using HRSystem.Repositories.DepartmentRepo;
using HRSystem.Repositories.EmployeeRepo;
using HRSystem.Repositories.ExceptionRepo;
using HRSystem.Repositories.GeneralSettingRepo;
using HRSystem.Repositories.HrRepo;
using HRSystem.Repositories.SalaryRepo;
using HRSystem.Repositories.WeeklyHolidayRepo;
using HRSystem.Services.AttendanceServ;
using HRSystem.Services.DepartmentServ;
using HRSystem.Services.EmployeeServ;
using HRSystem.Services.ExceptionServ;
using HRSystem.Services.GeneralSettingServ;
using HRSystem.Services.HrServ;
using HRSystem.Services.SalaryServ;
using HRSystem.Services.WeeklyHolidayServ;

namespace HRSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //DBContext + Identity Dbcontext Injaction
            builder.Services.AddDbContext<HRDbContext>(
            options => options.UseSqlServer(builder.Configuration.GetConnectionString("HrDB")));
            builder.Services.AddIdentity<Hr, IdentityRole>().AddEntityFrameworkStores<HRDbContext>();
            builder.Services.AddScoped<IAttendanceRepository, AttendanceRepository>();
            builder.Services.AddScoped<IDepartmentRepository, DepatrmentRepository>();
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddScoped<IHrRepository, HrRepository>();
            builder.Services.AddScoped<ISalaryRepository, SalaryRepository>();
            builder.Services.AddScoped<IGeneralSettingRepository, GeneralSettingRepository>();
            builder.Services.AddScoped<IWeeklyHolidayRepository, WeeklyHolidayRepository>();
            builder.Services.AddScoped<IExceptionRepository, ExceptionRepository>();
            builder.Services.AddScoped<IAttendanceService, AttendanceService>();
            builder.Services.AddScoped<IDepartmentService, DepartmentService>();
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();
            builder.Services.AddScoped<IHrService, HrService>();
            builder.Services.AddScoped<ISalaryService, SalaryService>();
            builder.Services.AddScoped<IGeneralSettingService, GeneralSettingService>();
            builder.Services.AddScoped<IWeeklyHolidayService, WeeklyHolidayService>();
            builder.Services.AddScoped<IExceptionService, ExceptionService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();

        }
    }
}