using HRSystem.Models;

namespace HRSystem.Repositories.ExceptionRepo
{
    public class ExceptionRepository : IExceptionRepository
    {
        private readonly HRDbContext context;
        public ExceptionRepository(HRDbContext context)
        {
            this.context = context;
        }

        public void Insert(ExceptionAttendance exception)
        {
            context.Exceptions.Add(exception);
            context.SaveChanges();
        }
    }
    
}
