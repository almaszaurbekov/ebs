using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataAccess
{
    public class EbsContext : DbContext
    {
        public EbsContext(DbContextOptions<EbsContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //{
            //    optionsBuilder
            //}
        }
    }
}