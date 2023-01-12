using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWebApp.DAL.Interfaces;
using TestWebApp.Domain.Entity;

namespace TestWebApp.DAL.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly photo_aggrContext _photo_aggrDb;

        public ClientRepository(photo_aggrContext photo_aggrDb)
        {
            _photo_aggrDb = photo_aggrDb;
        }

        public async Task<bool> Create(Client entity)
        {
            await _photo_aggrDb.Clients.AddAsync(entity);
            await _photo_aggrDb.SaveChangesAsync();

            return true;
        }

        public async Task<Client> Get(int id)
        {
            return await _photo_aggrDb.Clients.FirstOrDefaultAsync(x => x.ClientId == id);
        }

        public async Task<List<Client>> Select()
        {
            return await _photo_aggrDb.Clients.ToListAsync();
        }

        public async Task<bool> Delete(Client entity)
        {
            _photo_aggrDb.Clients.Remove(entity);
            await _photo_aggrDb.SaveChangesAsync();

            return true;
        }

        public async Task<Client> Update(Client entity)
        {
            _photo_aggrDb.Clients.Update(entity);
            await _photo_aggrDb.SaveChangesAsync();

            return entity;
        }

        public async Task<Client> GetByName(string name)
        {
            return await _photo_aggrDb.Clients.FirstOrDefaultAsync(x => x.ClientName == name);
        }
    }
}
