using ApiPractice.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApiPractice.Core.Repositories
{
    public interface IAccountRepository
    {
        Task<AppUser> GetAsync(Expression<Func<AppUser, bool>> exp);
    }
}
