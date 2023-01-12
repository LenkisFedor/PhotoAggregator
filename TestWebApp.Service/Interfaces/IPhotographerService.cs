using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWebApp.Domain.Response;
using TestWebApp.Domain.ViewModels.Photographer;


namespace TestWebApp.Service.Interfaces
{
    public interface IPhotographerService
    {
        Task<IBaseResponse<IEnumerable<Domain.Entity.Photographer>>> GetPhotographers();

        Task<IBaseResponse<PhotographerViewModel>> GetPhotographer(int id);

        Task<IBaseResponse<PhotographerViewModel>> CreatePhotographer(PhotographerViewModel PhotographerViewModel);

        Task<IBaseResponse<bool>> DeletePhotographer(int id);

        Task<IBaseResponse<Domain.Entity.Photographer>> GetPhotographerByName(string name);

        Task<IBaseResponse<Domain.Entity.Photographer>> Edit(int id, PhotographerViewModel model);
    }
}
