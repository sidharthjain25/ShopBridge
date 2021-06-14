using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataLayer
{
    public class DatabaseContext : DbContext
    {
        private static IConfiguration _configuration;
        public DatabaseContext(IConfiguration configuration)
        {
            _configuration = configuration;
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<BaseProjectEntities, Transition.Data.Migrations.Configuration>());
            ////Database.SetInitializer(new MigrateDatabaseToLatestVersion<BaseProjectEntities, DatabaseConfiguration<DatabaseInitialiser>>());
            Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("BaseProjectEntities"));
                optionsBuilder.UseLazyLoadingProxies();

            }
        }
        public DbSet<User> User { get; set; }
        public DbSet<Inventory> Address { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    ID = 1,
                    FullName = "Sidharth Jain",
                    UserName = "sidharthjain",
                    Email = "Shakespeare",
                    Password = "xyx123",
                    ContactNumber = "95089532233"

                },
                new User
                {
                    ID = 2,
                    FullName = "Test User",
                    UserName = "UserNamw",
                    Email = "Shakespeare",
                    Password = "xyx123",
                    ContactNumber = "95089532233"

                }

            );
        }

    }
}
