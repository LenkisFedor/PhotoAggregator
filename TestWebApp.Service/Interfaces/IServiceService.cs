using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWebApp.Domain.Response;
using TestWebApp.Domain.Entity;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Runtime.ConstrainedExecution;
using TestWebApp.Domain.ViewModels.Service;

namespace TestWebApp.Service.Interfaces
{
    public interface IServiceService
    {
        Task<IBaseResponse<IEnumerable<Domain.Entity.Service>>> GetServices();

        Task<IBaseResponse<ServiceViewModel>> GetService(int id);

        Task<IBaseResponse<ServiceViewModel>> CreateService(ServiceViewModel ServiceViewModel);

        Task<IBaseResponse<bool>> DeleteService(int id);

        Task<IBaseResponse<Domain.Entity.Service>> GetServiceByName(string name);

        Task<IBaseResponse<Domain.Entity.Service>> Edit(int id, ServiceViewModel model);
    }
}
