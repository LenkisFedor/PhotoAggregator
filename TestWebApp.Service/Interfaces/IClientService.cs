using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWebApp.Domain.Response;
using TestWebApp.Domain.ViewModels.Client;

namespace TestWebApp.Service.Interfaces
{
    public interface IClientService
    {
        Task<IBaseResponse<IEnumerable<Domain.Entity.Client>>> GetClients();

        Task<IBaseResponse<ClientViewModel>> GetClient(int id);

        Task<IBaseResponse<ClientViewModel>> CreateClient(ClientViewModel ClientViewModel);

        Task<IBaseResponse<bool>> DeleteClient(int id);

        Task<IBaseResponse<Domain.Entity.Client>> GetClientByName(string name);

        Task<IBaseResponse<Domain.Entity.Client>> Edit(int id, ClientViewModel model);
    }
}
