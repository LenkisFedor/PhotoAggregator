using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWebApp.Domain.Response;
using TestWebApp.Domain.ViewModels.Employee;


namespace TestWebApp.Service.Interfaces
{
    public interface IEmployeeService
    {
        Task<IBaseResponse<IEnumerable<Domain.Entity.Employee>>> GetEmployees();

        Task<IBaseResponse<EmployeeViewModel>> GetEmployee(int id);

        Task<IBaseResponse<EmployeeViewModel>> CreateEmployee(EmployeeViewModel EmployeeViewModel);

        Task<IBaseResponse<bool>> DeleteEmployee(int id);

        Task<IBaseResponse<Domain.Entity.Employee>> GetEmployeeByName(string name);

        Task<IBaseResponse<Domain.Entity.Employee>> Edit(int id, EmployeeViewModel model);
    }
}
