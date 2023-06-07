using ApiPractice.Core.Entities;
using ApiPractice.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApiPractice.Data.Repositories
{
    public class CityRepository : ICityRepository
    {
        private readonly StoreDbContext _context;

        public CityRepository(StoreDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(City city)
        {
            await _context.Cities.AddAsync(city);
        }

        public int Commit()
        {
           return _context.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
           return await _context.SaveChangesAsync();
        }

        public void Delete(City city)
        {
            _context.Remove(city);
        }

        public IQueryable<City> GetAll(Expression<Func<City, bool>> exp)
        {
            return _context.Cities.Where(exp);
        }

        public async Task<City> GetAsync(Expression<Func<City, bool>> exp)
        {
            return await _context.Cities.FirstOrDefaultAsync(exp);
        }
    }
}
