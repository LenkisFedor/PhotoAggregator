using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWebApp.Domain.Entity;

namespace TestWebApp.DAL.Interfaces
{
    public interface IPhotographerRepository:IBaseRepository<Photographer>
    {
        Task<Domain.Entity.Photographer> GetByName(string name);
    }
}
