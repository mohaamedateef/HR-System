using HRSystem.Models;

namespace HRSystem.Repositories.DepartmentRepo
{
    public class DepatrmentRepository : IDepartmentRepository
    {
        private readonly HRDbContext context;
        public DepatrmentRepository(HRDbContext context)
        {
            this.context = context;
        }
    }
}
