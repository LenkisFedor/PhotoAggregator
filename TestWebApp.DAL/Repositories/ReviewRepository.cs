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
    public class ReviewRepository : IReviewRepository
    {
        private readonly photo_aggrContext _photo_aggrDb;

        public ReviewRepository(photo_aggrContext photo_aggrDb)
        {
            _photo_aggrDb = photo_aggrDb;
        }

        public async Task<bool> Create(Review entity)
        {
            await _photo_aggrDb.Reviews.AddAsync(entity);
            await _photo_aggrDb.SaveChangesAsync();

            return true;
        }

        public async Task<Review> Get(int id)
        {
            return await _photo_aggrDb.Reviews.FirstOrDefaultAsync(x => x.ReviewId == id);
        }

        public async Task<List<Review>> Select()
        {
            return await _photo_aggrDb.Reviews.ToListAsync();
        }

        public async Task<bool> Delete(Review entity)
        {
            _photo_aggrDb.Reviews.Remove(entity);
            await _photo_aggrDb.SaveChangesAsync();

            return true;
        }

        public async Task<Review> Update(Review entity)
        {
            _photo_aggrDb.Reviews.Update(entity);
            await _photo_aggrDb.SaveChangesAsync();

            return entity;
        }
    }
}