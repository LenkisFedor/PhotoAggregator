using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWebApp.Domain.Response;
using TestWebApp.Domain.ViewModels.User;


namespace TestWebApp.Service.Interfaces
{
    public interface IUserService
    {
        Task<IBaseResponse<IEnumerable<Domain.Entity.User>>> GetUsers();

        Task<IBaseResponse<UserViewModel>> GetUser(int id);

        Task<IBaseResponse<UserViewModel>> CreateUser(UserViewModel UserViewModel);

        Task<IBaseResponse<bool>> DeleteUser(int id);

        Task<IBaseResponse<Domain.Entity.User>> GetUserByName(string name);

        Task<IBaseResponse<Domain.Entity.User>> Edit(int id, UserViewModel model);
    }
}
