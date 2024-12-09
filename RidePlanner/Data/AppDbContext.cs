
using Microsoft.EntityFrameworkCore;

using RidePlanner.Models.Entities;
using RidePlanner.Data.Configurations;
namespace RidePlanner.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<BusCompany> BusCompanies { get; set; }
        public DbSet<Buses> Buses { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        
        modelBuilder.ApplyConfiguration(new BusCompanyConfiguration());
        modelBuilder.ApplyConfiguration(new BusesConfiguration());


        ApplyGlobalQueryFilters(modelBuilder);

    }
        private void ApplyGlobalQueryFilters(ModelBuilder modelBuilder) {


            modelBuilder.Entity<BusCompany>()
              .HasQueryFilter(b => !b.IsDeleted);
        }

    }
}
