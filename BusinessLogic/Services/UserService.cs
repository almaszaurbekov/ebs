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

        /// <summary>
        /// Group By SQL Command
        /// </summary>
        public async Task<List<ShortUserList>> GetShortUserList(string sql)
        {
            var entities = new List<ShortUserList>();
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
                            entities.Add(new ShortUserList { Id = reader.GetInt32(0), Count = reader.GetInt32(1) });
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

            return entities;
        }
    }
}