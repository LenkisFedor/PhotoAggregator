using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestWebApp.DAL.Interfaces;
using TestWebApp.Domain.Entity;


namespace TestWebApp.DAL.Repositories
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly photo_aggrContext _photo_aggrDb;

        public ServiceRepository(photo_aggrContext photo_aggrDb)
        {
            _photo_aggrDb = photo_aggrDb;
        }

        public async Task<bool> Create(Service entity)
        {
            await _photo_aggrDb.Services.AddAsync(entity);
            await _photo_aggrDb.SaveChangesAsync();

            return true;
        }

        public async Task<Service> Get(int id)
        {
            return await _photo_aggrDb.Services.FirstOrDefaultAsync(x => x.ServiceId == id);
        }

        public async Task<List<Service>> Select()
        {
            return await _photo_aggrDb.Services.ToListAsync();
        }

        public async Task<bool> Delete(Service entity)
        {
            _photo_aggrDb.Services.Remove(entity);
            await _photo_aggrDb.SaveChangesAsync();

            return true;
        }

        public async Task<Service> Update(Service entity)
        {
            _photo_aggrDb.Services.Update(entity);
            await _photo_aggrDb.SaveChangesAsync();

            return entity;
        }

        public async Task<Service> GetByName(string name)
        {
            return await _photo_aggrDb.Services.FirstOrDefaultAsync(x => x.ServiceName == name);
        }
    }
}
