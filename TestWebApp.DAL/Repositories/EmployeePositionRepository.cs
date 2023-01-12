using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWebApp.Domain.Entity;
using TestWebApp.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace TestWebApp.DAL.Repositories
{
    public class EmployeePositionRepository : IEmployeePositionRepository
    {
        private readonly photo_aggrContext _photo_aggrDb;

        public EmployeePositionRepository(photo_aggrContext photo_aggrDb)
        {
            _photo_aggrDb = photo_aggrDb;
        }

        public async Task<bool> Create(EmployeePosition entity)
        {
            await _photo_aggrDb.EmployeePositions.AddAsync(entity);
            await _photo_aggrDb.SaveChangesAsync();

            return true;
        }

        public async Task<EmployeePosition> Get(int id)
        {
            return await _photo_aggrDb.EmployeePositions.FirstOrDefaultAsync(x => x.PositionId == id);
        }

        public async Task<List<EmployeePosition>> Select()
        {
            return await _photo_aggrDb.EmployeePositions.ToListAsync();
        }

        public async Task<bool> Delete(EmployeePosition entity)
        {
            _photo_aggrDb.EmployeePositions.Remove(entity);
            await _photo_aggrDb.SaveChangesAsync();

            return true;
        }

        public async Task<EmployeePosition> Update(EmployeePosition entity)
        {
            _photo_aggrDb.EmployeePositions.Update(entity);
            await _photo_aggrDb.SaveChangesAsync();

            return entity;
        }

        public async Task<EmployeePosition> GetByName(string name)
        {
            return await _photo_aggrDb.EmployeePositions.FirstOrDefaultAsync(x => x.PositionName == name);
        }
    }
}
