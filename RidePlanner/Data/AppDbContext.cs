﻿using Microsoft.EntityFrameworkCore;
using RidePlanner.Models.Entities;
using RidePlanner.Data.Configurations;

namespace RidePlanner.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<TaxiCompany> TaxiCompanies { get; set; }
        public DbSet<Taxi> Taxis { get; set; }
        public DbSet<TaxiReservations> TaxiReservations { get; set; }
        public DbSet<TaxiBookings> TaxiBookings { get; set; }
        public DbSet<BusSchedule> BusSchedules { get; set; }

        public DbSet<BusReservations> BusReservations { get; set; }
        public DbSet<BusCompany> BusCompanies { get; set; }
        public DbSet<Buses> Buses { get; set; }
        public DbSet<BusRoutes> BusRoutes { get; set; }


        public DbSet<BaseReview> Reviews { get; set; }
        public DbSet<UserReview> UserReviews { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new TaxiCompanyConfiguration());
            modelBuilder.ApplyConfiguration(new TaxiConfiguration());
            modelBuilder.ApplyConfiguration(new TaxiReservationsConfiguration());
            modelBuilder.ApplyConfiguration(new BusScheduleConfiguration());
           
            modelBuilder.ApplyConfiguration(new BusReservationsConfiguration());
            modelBuilder.ApplyConfiguration(new TaxiBookingConfiguration());

            ApplyGlobalQueryFilters(modelBuilder);

        }
    private void ApplyGlobalQueryFilters(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
        .HasQueryFilter(u => !u.IsDeleted);

            modelBuilder.Entity<BusCompany>()
                .HasQueryFilter(bc => !bc.IsDeleted);

            modelBuilder.Entity<Buses>()
                .HasQueryFilter(b => !b.BusCompany.IsDeleted);

            modelBuilder.Entity<BusRoutes>()
                .HasQueryFilter(b => !b.BusCompany.IsDeleted);

            modelBuilder.Entity<TaxiCompany>()
               .HasQueryFilter(tc => !tc.IsDeleted);

            modelBuilder.Entity<BusReservations>()
                .HasQueryFilter(br => !br.User.IsDeleted);

            modelBuilder.Entity<TaxiBookings>()
                .HasQueryFilter(tb => !tb.TaxiCompany.IsDeleted);

            modelBuilder.Entity<TaxiReservations>()
                 .HasQueryFilter(tr => !tr.TaxiCompany.IsDeleted);

            modelBuilder.Entity<Taxi>()
                 .HasQueryFilter(t => !t.TaxiCompany.IsDeleted);

            modelBuilder.Entity<BusSchedule>()
                .HasQueryFilter(bs => !bs.Bus.BusCompany.IsDeleted);

            modelBuilder.Entity<BaseReview>()
             .HasDiscriminator<string>("ReviewType")
             .HasValue<BaseReview>("BaseReview")
             .HasValue<UserReview>("UserReview");

            base.OnModelCreating(modelBuilder);
        }

    }
}