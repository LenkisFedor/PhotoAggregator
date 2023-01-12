using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using TestWebApp.DAL.Interfaces;
using TestWebApp.Domain.Entity;


namespace TestWebApp.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly photo_aggrContext _photo_aggrDb;

        public UserRepository(photo_aggrContext photo_aggrDb)
        {
            _photo_aggrDb = photo_aggrDb;
        }

        public async Task<bool> Create(User entity)
        {
            await _photo_aggrDb.Users.AddAsync(entity);
            await _photo_aggrDb.SaveChangesAsync();

            return true;
        }

        public async Task<User> Get(int id)
        {
            return await _photo_aggrDb.Users.FirstOrDefaultAsync(x => x.UserId == id);
        }

        public async Task<List<User>> Select()
        {
            return await _photo_aggrDb.Users.ToListAsync();
        }

        public async Task<bool> Delete(User entity)
        {
            _photo_aggrDb.Users.Remove(entity);
            await _photo_aggrDb.SaveChangesAsync();

            return true;
        }

        public async Task<User> Update(User entity)
        {
            _photo_aggrDb.Users.Update(entity);
            await _photo_aggrDb.SaveChangesAsync();

            return entity;
        }

        public async Task<User> GetByLoggin(string name)
        {
            return await _photo_aggrDb.Users.FirstOrDefaultAsync(x => x.UserLogin == name);
        }
    }
}


