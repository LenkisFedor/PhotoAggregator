using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace TestWebApp.DAL.Interfaces
{
    public interface IServiceRepository : IBaseRepository<Domain.Entity.Service>
    {
        Task<Domain.Entity.Service> GetByName(string name);
    }
}
