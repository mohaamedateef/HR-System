using HRSystem.Repositories.EmployeeRepo;

namespace HRSystem.Services.EmployeeServ
{
    public interface IEmployeeService : IEmployeeRepository
    {
        void InsertViewModel(EmployeeViewModel employeeViewModel);
        EmployeeViewModel GetViewModel(int id);
        void  UpdateEmployeeWithViewModel(EmployeeViewModel addEmployeeViewModel);
       

    }
}
