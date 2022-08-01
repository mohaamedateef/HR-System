using HRSystem.Repositories.SalaryRepo;

namespace HRSystem.Services.SalaryServ
{
    public class SalaryService : ISalaryService
    {
        private readonly ISalaryRepository SalaryRepo;
        public SalaryService(ISalaryRepository SalaryRepo)
        {
            this.SalaryRepo = SalaryRepo;
        }
    }
}
