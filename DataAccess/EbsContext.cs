using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using Resources;

namespace DataAccess
{
    public class EbsContext : DbContext
    {
        public EbsContext(DbContextOptions<EbsContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string adminRoleName = "admin";
            string userRoleName = "user";

            string adminEmail = "foxxychmoxy@gmail.com";
            string adminPassword = "123qweAS1!";

            Role adminRole = new Role { Id = Guid.NewGuid(), Name = adminRoleName };
            Role userRole = new Role { Id = Guid.NewGuid(), Name = userRoleName };
            User adminUser = new User { Id = 1, Email = adminEmail, Password = PasswordHelper.Hash(adminPassword), RoleId = adminRole.Id };

            modelBuilder.Entity<Role>().HasData(new Role[] { adminRole, userRole });
            modelBuilder.Entity<User>().HasData(new User[] { adminUser });

            base.OnModelCreating(modelBuilder);
        }
    }
}