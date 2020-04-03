using DataAccess.Models;
using BusinessLogic.Services.Base;
using DataAccess;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public interface IUserService : IService<User>
    {
        Task<List<ShortUserList>> GetShortUserList(string sql);
    }

    public class UserService : EntityService<User>, IUserService
    {
        public UserService(EbsContext context) : base(context) { }

        public override async Task<List<User>> GetAll()
        {
            return await DbSet
                    .Include(u => u.Role)
                    .ToListAsync();
        }

        public override async Task<User> Find(Expression<Func<User, bool>> predicate)
        {
            return await DbSet
                .Include(u => u.Role)
                .Where(predicate)
                .FirstOrDefaultAsync();
        }

        public async Task<List<ShortUserList>> GetShortUserList(string sql)
        {
            return await context.GetShortUserList(sql);
        }
    }
}