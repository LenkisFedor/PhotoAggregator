using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWebApp.Domain.Response;
using TestWebApp.Domain.ViewModels.Publication;


namespace TestWebApp.Service.Interfaces
{
    public interface IPublicationsService
    {
        Task<IBaseResponse<IEnumerable<Domain.Entity.Publication>>> GetPublications();

        Task<IBaseResponse<PublicationViewModel>> GetPublication(int id);

        Task<IBaseResponse<PublicationViewModel>> CreatePublication(PublicationViewModel PublicationViewModel);

        Task<IBaseResponse<bool>> DeletePublication(int id);

        Task<IBaseResponse<Domain.Entity.Publication>> GetPublicationByName(string name);

        Task<IBaseResponse<Domain.Entity.Publication>> Edit(int id, PublicationViewModel model);
    }
}
