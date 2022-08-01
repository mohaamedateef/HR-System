using HRSystem.Models;

namespace HRSystem.Repositories.SalaryRepo
{
    public class SalaryRepository : ISalaryRepository
    {
        private readonly HRDbContext context;
        public SalaryRepository(HRDbContext context)
        {
            this.context = context;
        }
    }
}
