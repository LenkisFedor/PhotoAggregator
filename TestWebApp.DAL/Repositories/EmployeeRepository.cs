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
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly photo_aggrContext _photo_aggrDb;

        public EmployeeRepository(photo_aggrContext photo_aggrDb)
        {
            _photo_aggrDb = photo_aggrDb;
        }

        public async Task<bool> Create(Employee entity)
        {
            await _photo_aggrDb.Employees.AddAsync(entity);
            await _photo_aggrDb.SaveChangesAsync();

            return true;
        }

        public async Task<Employee> Get(int id)
        {
            return await _photo_aggrDb.Employees.FirstOrDefaultAsync(x => x.EmployeeId == id);
        }

        public async Task<List<Employee>> Select()
        {
            return await _photo_aggrDb.Employees.ToListAsync();
        }

        public async Task<bool> Delete(Employee entity)
        {
            _photo_aggrDb.Employees.Remove(entity);
            await _photo_aggrDb.SaveChangesAsync();

            return true;
        }

        public async Task<Employee> Update(Employee entity)
        {
            _photo_aggrDb.Employees.Update(entity);
            await _photo_aggrDb.SaveChangesAsync();

            return entity;
        }

        public async Task<Employee> GetByName(string name)
        {
            return await _photo_aggrDb.Employees.FirstOrDefaultAsync(x => x.EmployeeName == name);
        }
    }
}
