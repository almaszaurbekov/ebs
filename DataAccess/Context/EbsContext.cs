using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using Common;
using DataAccess.Context;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder = SeedData.Initialize(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
    }
}