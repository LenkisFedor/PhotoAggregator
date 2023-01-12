using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWebApp.Domain.Response;
using TestWebApp.Domain.ViewModels.EmployeePosition;


namespace TestWebApp.Service.Interfaces
{
    public interface IEmployeePositionService
    {
        Task<IBaseResponse<IEnumerable<Domain.Entity.EmployeePosition>>> GetEmployeePositions();

        Task<IBaseResponse<EmployeePositionViewModel>> GetEmployeePosition(int id);

        Task<IBaseResponse<EmployeePositionViewModel>> CreateEmployeePosition(EmployeePositionViewModel EmployeePositionViewModel);

        Task<IBaseResponse<bool>> DeleteEmployeePosition(int id);

        Task<IBaseResponse<Domain.Entity.EmployeePosition>> GetEmployeePositionByName(string name);

        Task<IBaseResponse<Domain.Entity.EmployeePosition>> Edit(int id, EmployeePositionViewModel model);
    }
}
