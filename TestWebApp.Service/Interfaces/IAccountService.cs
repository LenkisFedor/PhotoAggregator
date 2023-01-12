using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TestWebApp.Domain.Response;
using TestWebApp.Domain.ViewModels.Account;

namespace TestWebApp.Service.Interfaces
{
    public interface IAccountService
    {
        Task<IBaseResponse<ClaimsIdentity>> Register(RegisterViewModel model);

        Task<IBaseResponse<ClaimsIdentity>> Login(LoginViewModel model);
    }
}
