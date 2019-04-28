using Microsoft.EntityFrameworkCore;
using MyCleverApp.Chat.Model.Entities;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }

        public override int SaveChanges()
        {
            AddEntityTrackInfo();
            return base.SaveChanges();
        }

        private void AddEntityTrackInfo()
        {
            DateTime currentDate = DateTime.UtcNow;
            foreach (var entry in ChangeTracker.Entries ().Where (e => e.Entity is EntityBase))
            {
                var entity = entry.Entity as EntityBase;
                if (entry.State == EntityState.Added)
                {
                    entity.CreatedOn = currentDate;
                    entity.ModifiedOn = currentDate;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entity.ModifiedOn = currentDate;
                }
            }
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
