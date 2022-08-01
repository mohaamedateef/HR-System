using HRSystem.Repositories.DepartmentRepo;

namespace HRSystem.Services.DepartmentServ
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository DepartmentRepo;
        public DepartmentService(IDepartmentRepository DepartmentRepo)
        {
            this.DepartmentRepo = DepartmentRepo;
        }
    }
}
