using Microsoft.EntityFrameworkCore;
using MyCleverApp.Chat.Model.Entities;
using System;
using System.Linq;

namespace MyCleverApp.Chat.Model
{
    public class ChatDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<ContactList> ContactLists { get; set; }
        public ChatDbContext(DbContextOptions options) : base (options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            CreateUsers(modelBuilder);
        }

        private void CreateUsers(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<User>().HasData(new User {
            //    Username = "richard",
            //    CreatedOn = DateTime.UtcNow,
            //    ModifiedOn = DateTime.UtcNow,

            //});
            //modelBuilder.Entity<User> ().HasData(Enumerable.Range(1, 100).Select(n => new User
            //{
            //    Username = $"user{n}",
            //    DisplayName = $"DisplayName{n}",
            //    DisplayImage = $"NoDisplayImage",
            //    CreatedOn = DateTime.UtcNow,
            //    ModifiedOn = DateTime.UtcNow
            //}));
        }
    }
}
