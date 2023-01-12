using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWebApp.Domain.Response;
using TestWebApp.Domain.ViewModels.Request;


namespace TestWebApp.Service.Interfaces
{
    public interface IRequestService
    {
        Task<IBaseResponse<IEnumerable<Domain.Entity.Request>>> GetRequests();

        Task<IBaseResponse<RequestViewModel>> GetRequest(int id);

        Task<IBaseResponse<RequestViewModel>> CreateRequest(RequestViewModel RequestViewModel);

        Task<IBaseResponse<bool>> DeleteRequest(int id);

        Task<IBaseResponse<Domain.Entity.Request>> GetRequestByName(string name);

        Task<IBaseResponse<Domain.Entity.Request>> Edit(int id, RequestViewModel model);
    }
}
