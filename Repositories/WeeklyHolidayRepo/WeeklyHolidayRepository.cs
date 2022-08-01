using HRSystem.Models;

namespace HRSystem.Repositories.WeeklyHolidayRepo
{
    public class WeeklyHolidayRepository : IWeeklyHolidayRepository
    {
        private readonly HRDbContext context;
        public WeeklyHolidayRepository(HRDbContext context)
        {
            this.context = context;
        }
    }
}
