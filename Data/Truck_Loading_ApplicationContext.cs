using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using Truck_Loading_Application.Models;

namespace Truck_Loading_Application.Data
{
    public class Truck_Loading_ApplicationContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public Truck_Loading_ApplicationContext(DbContextOptions<Truck_Loading_ApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<CargoItem> CargoItems { get; set; }
        public DbSet<CargoRequest> CargoRequests { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Truck> Trucks { get; set; }
        public DbSet<TruckDriver> TruckDrivers { get; set; }
        public DbSet<TruckRoute> TruckRoutes { get; set; }
        public DbSet<LoadPlan> LoadPlans { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ApplicationUser relationships
            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.CreatedReports)
                .WithOne(r => r.CreatedByUser)
                .HasForeignKey(r => r.CreatedByUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.UpdatedReports)
                .WithOne(r => r.UpdatedByUser)
                .HasForeignKey(r => r.UpdatedByUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.CargoRequests)
                .WithOne(cr => cr.Client)
                .HasForeignKey(cr => cr.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            // Truck relationships
            modelBuilder.Entity<Truck>()
                .HasMany(t => t.Trips)
                .WithOne(tr => tr.Truck)
                .HasForeignKey(tr => tr.TruckId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Truck>()
                .HasMany(t => t.Reports)
                .WithOne(r => r.Truck)
                .HasForeignKey(r => r.TruckId)
                .OnDelete(DeleteBehavior.Restrict);

            // LoadPlan relationships
            modelBuilder.Entity<LoadPlan>()
                .HasOne(lp => lp.Truck)
                .WithMany()
                .HasForeignKey(lp => lp.TruckId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<LoadPlan>()
                .HasOne(lp => lp.Trip)
                .WithMany()
                .HasForeignKey(lp => lp.TripId)
                .OnDelete(DeleteBehavior.NoAction);

            // Ensure all entities use Guid for their ID properties
            // This is implicitly done when you define the ID properties of your entities as Guid
            // No need for explicit configuration here unless you have specific needs

            // Add other relationship configurations as needed
        }
    }
}
