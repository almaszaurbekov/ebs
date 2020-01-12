using BusinessLogic.Services.Base;
using DataAccess;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public interface IUserService : IService<User> { }

    public class UserService : EntityService<User>, IUserService
    {
        public UserService(EbsContext context) : base(context) { }

        public override async Task<User> Find(Expression<Func<User, bool>> predicate)
        {
            return await DbSet
                .Include(u => u.Role)
                .Where(predicate)
                .FirstOrDefaultAsync();
        }
    }
}