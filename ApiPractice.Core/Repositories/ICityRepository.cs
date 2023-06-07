using ApiPractice.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApiPractice.Core.Repositories
{
    public interface ICityRepository
    {
        Task AddAsync(City city);
        IQueryable<City> GetAll(Expression<Func<City, bool>> exp);
        Task<City> GetAsync(Expression<Func<City,bool>> exp);

        void Delete(City city);
        int Commit();
        Task<int> CommitAsync();
    }
}
