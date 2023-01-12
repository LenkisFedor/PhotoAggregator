using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWebApp.Domain.Entity;
using TestWebApp.DAL.Interfaces;


namespace TestWebApp.DAL.Repositories
{
    public class RequestRepository : IRequestRepository
    {
        private readonly photo_aggrContext _photo_aggrDb;

        public RequestRepository(photo_aggrContext photo_aggrDb)
        {
            _photo_aggrDb = photo_aggrDb;
        }

        public async Task<bool> Create(Request entity)
        {
            await _photo_aggrDb.Requests.AddAsync(entity);
            await _photo_aggrDb.SaveChangesAsync();

            return true;
        }

        public async Task<Request> Get(int id)
        {
            return await _photo_aggrDb.Requests.FirstOrDefaultAsync(x => x.RequestId == id);
        }

        public async Task<List<Request>> Select()
        {
            return await _photo_aggrDb.Requests.ToListAsync();
        }

        public async Task<bool> Delete(Request entity)
        {
            _photo_aggrDb.Requests.Remove(entity);
            await _photo_aggrDb.SaveChangesAsync();

            return true;
        }

        public async Task<Request> Update(Request entity)
        {
            _photo_aggrDb.Requests.Update(entity);
            await _photo_aggrDb.SaveChangesAsync();

            return entity;
        }
    }
}
