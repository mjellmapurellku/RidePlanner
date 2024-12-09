﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RidePlanner.Models.Entities;

namespace RidePlanner.Data.Configurations
{
    public class BusScheduleConfiguration : IEntityTypeConfiguration<BusSchedule>
    {
        public void Configure(EntityTypeBuilder<BusSchedule> builder)
        {
            ConfigureKeys(builder);
            ConfigureProperties(builder);
            ConfigureDefaults(builder);
            ConfigureRelationships(builder);
        }

        private void ConfigureKeys(EntityTypeBuilder<BusSchedule> builder)
        {
            builder.HasKey(bs => bs.ScheduleId);
        }

        private void ConfigureProperties(EntityTypeBuilder<BusSchedule> builder)
        {
            builder.Property(bs => bs.ScheduleId)
                .ValueGeneratedOnAdd();

            builder.Property(bs => bs.DepartureTime)
                .IsRequired();

            builder.Property(bs => bs.ArrivalTime)
                .IsRequired();

            builder.Property(bs => bs.Price)
                .IsRequired()
                .HasColumnType("decimal(18, 2)")
                .HasPrecision(18, 2);

            builder.Property(bs => bs.AvailableSeats)
                .IsRequired();

            builder.Property(bs => bs.Status)
                .IsRequired();

            builder.Property(bs => bs.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(bs => bs.UpdatedAt)
                .IsRequired(false);
        }

        private void ConfigureDefaults(EntityTypeBuilder<BusSchedule> builder)
        {
            builder.Property(bs => bs.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()");
        }

        private void ConfigureRelationships(EntityTypeBuilder<BusSchedule> builder)
        {
            builder.HasOne(bs => bs.Bus)
                .WithMany()
                .HasForeignKey(bs => bs.BusId);

            builder.HasOne(bs => bs.Route)
                .WithMany()
                .HasForeignKey(bs => bs.RouteId);
        }
    }
}