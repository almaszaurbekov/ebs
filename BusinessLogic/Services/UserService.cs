using BusinessLogic.Models;
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
        Task<List<ShortUserList>> GetUserListAscending(string sql);
    }

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

        public async Task<List<ShortUserList>> GetUserListAscending(string sql)
        {
            var groups = new List<ShortUserList>();
            var conn = context.Database.GetDbConnection();

            try
            {
                await conn.OpenAsync();
                using (var command = conn.CreateCommand())
                {
                    command.CommandText = sql;
                    DbDataReader reader = await command.ExecuteReaderAsync();

                    if (reader.HasRows)
                    {
                        while (await reader.ReadAsync())
                        {
                            var row = new ShortUserList { Id = reader.GetInt32(0), Email = reader.GetString(1) };
                            groups.Add(row);
                        }
                    }
                    reader.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

            return groups;
        }
    }
}