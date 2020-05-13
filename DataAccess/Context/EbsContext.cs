using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using DataAccess.Context;
using System.Threading.Tasks;
using System.Collections.Generic;
using DataAccess.Models;
using Microsoft.Data.SqlClient;

namespace DataAccess
{
    public class EbsContext : DbContext
    {
        public EbsContext(DbContextOptions<EbsContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<BcBook> BcBooks { get; set; }
        public DbSet<DialogControl> DialogControls { get; set; }
        public DbSet<BookTransaction> BookTransactions { get; set; }
        public DbSet<Log> Logs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedData.Initialize(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        public async Task<List<GoodBookList>> GetBooksByCondition(string sql, bool inGoodCondition)
        {
            try
            {
                SqlParameter param = new SqlParameter("@inGoodCondition", 
                    Convert.ToInt32(inGoodCondition));

                return await Set<GoodBookList>()
                    .FromSqlRaw(sql, param)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<BookGroup>> GetBooksCountByAuthor(string sql)
        {
            try
            {
                return await Set<BookGroup>()
                    .FromSqlRaw(sql)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<ShortUserList>> GetShortUserList(string sql)
        {
            try
            {
                return await Set<ShortUserList>()
                    .FromSqlRaw(sql)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}