using HRSystem.Repositories.WeeklyHolidayRepo;

namespace HRSystem.Services.WeeklyHolidayServ
{
    public class WeeklyHolidayService : IWeeklyHolidayService
    {
        private readonly IWeeklyHolidayRepository WeeklyHolidayRepo;
        public WeeklyHolidayService(IWeeklyHolidayRepository WeeklyHolidayRepo)
        {
            this.WeeklyHolidayRepo = WeeklyHolidayRepo;
        }
    }
}
