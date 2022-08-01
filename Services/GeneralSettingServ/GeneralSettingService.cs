using HRSystem.Repositories.GeneralSettingRepo;

namespace HRSystem.Services.GeneralSettingServ
{
    public class GeneralSettingService : IGeneralSettingService
    {
        private readonly IGeneralSettingRepository GeneralRepo;
        public GeneralSettingService(IGeneralSettingRepository GeneralRepo)
        {
            this.GeneralRepo = GeneralRepo;
        }
    }
}
