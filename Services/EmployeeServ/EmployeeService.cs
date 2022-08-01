using HRSystem.Repositories.EmployeeRepo;

namespace HRSystem.Services.EmployeeServ
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository EmployeeRepo;
        public EmployeeService(IEmployeeRepository EmployeeRepo)
        {
            this.EmployeeRepo = EmployeeRepo;
        }
    }
}
