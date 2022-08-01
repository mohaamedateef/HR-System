using HRSystem.Models;

namespace HRSystem.Repositories.GeneralSettingRepo
{
    public class GeneralSettingRepository : IGeneralSettingRepository
    {
        private readonly HRDbContext context;
        public GeneralSettingRepository(HRDbContext context)
        {
            this.context = context;
        }
    }
}
