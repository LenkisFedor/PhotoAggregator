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
    public class PhotographerRepository : IPhotographerRepository
    {
        private readonly photo_aggrContext _photo_aggrDb;

        public PhotographerRepository(photo_aggrContext photo_aggrDb)
        {
            _photo_aggrDb = photo_aggrDb;
        }

        public async Task<bool> Create(Photographer entity)
        {
            await _photo_aggrDb.Photographers.AddAsync(entity);
            await _photo_aggrDb.SaveChangesAsync();

            return true;
        }

        public async Task<Photographer> Get(int id)
        {
            return await _photo_aggrDb.Photographers.FirstOrDefaultAsync(x => x.PhotographerId == id);
        }

        public async Task<List<Photographer>> Select()
        {
            return await _photo_aggrDb.Photographers.ToListAsync();
        }

        public async Task<bool> Delete(Photographer entity)
        {
            _photo_aggrDb.Photographers.Remove(entity);
            await _photo_aggrDb.SaveChangesAsync();

            return true;
        }

        public async Task<Photographer> Update(Photographer entity)
        {
            _photo_aggrDb.Photographers.Update(entity);
            await _photo_aggrDb.SaveChangesAsync();

            return entity;
        }

        public async Task<Photographer> GetByName(string name)
        {
            return await _photo_aggrDb.Photographers.FirstOrDefaultAsync(x => x.PhotographerName == name);
        }
    }
}
