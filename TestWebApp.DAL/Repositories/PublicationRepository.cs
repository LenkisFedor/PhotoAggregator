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
    public class PublicationRepository : IPublicationRepository
    {
        private readonly photo_aggrContext _photo_aggrDb;

        public PublicationRepository(photo_aggrContext photo_aggrDb)
        {
            _photo_aggrDb = photo_aggrDb;
        }

        public async Task<bool> Create(Publication entity)
        {
            await _photo_aggrDb.Publications.AddAsync(entity);
            await _photo_aggrDb.SaveChangesAsync();

            return true;
        }

        public async Task<Publication> Get(int id)
        {
            return await _photo_aggrDb.Publications.FirstOrDefaultAsync(x => x.PublicationId == id);
        }

        public async Task<List<Publication>> Select()
        {
            return await _photo_aggrDb.Publications.ToListAsync();
        }

        public async Task<bool> Delete(Publication entity)
        {
            _photo_aggrDb.Publications.Remove(entity);
            await _photo_aggrDb.SaveChangesAsync();

            return true;
        }

        public async Task<Publication> Update(Publication entity)
        {
            _photo_aggrDb.Publications.Update(entity);
            await _photo_aggrDb.SaveChangesAsync();

            return entity;
        }
    }
}
