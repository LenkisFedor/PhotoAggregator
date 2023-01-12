using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWebApp.DAL.Interfaces
{
    public interface IUserRepository : IBaseRepository<Domain.Entity.User>
    {
        Task<Domain.Entity.User> GetByLoggin(string name);
    }
}
