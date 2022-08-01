using HRSystem.Models;

namespace HRSystem.Repositories.EmployeeRepo
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly HRDbContext context;
        public EmployeeRepository(HRDbContext context)
        {
            this.context = context;
        }

    }
}
