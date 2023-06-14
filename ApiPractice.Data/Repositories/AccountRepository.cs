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
    public class AccountRepository : IAccountRepository
    {
        private readonly StoreDbContext _context;

        public AccountRepository(StoreDbContext context)
        {
            _context = context;
        }

        public async Task<AppUser> GetAsync(Expression<Func<AppUser, bool>> exp)
        {
            return await _context.AppUsers.FirstOrDefaultAsync(exp);
        }
    }
}
