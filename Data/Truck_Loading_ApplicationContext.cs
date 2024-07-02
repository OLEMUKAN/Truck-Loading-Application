using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Truck_Loading_Application.Models;

namespace Truck_Loading_Application.Data
{
    public class Truck_Loading_ApplicationContext : DbContext
    {
        public Truck_Loading_ApplicationContext(DbContextOptions<Truck_Loading_ApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<Truck_Loading_Application.Models.ApplicationUser> ApplicationUser { get; set; } = default!;
        public DbSet<Truck_Loading_Application.Models.Report> Report { get; set; } = default!;
        public DbSet<Truck_Loading_Application.Models.CargoItem> CargoItem { get; set; } = default!;
        public DbSet<Truck_Loading_Application.Models.CargoRequest> CargoRequest { get; set; } = default!;
        public DbSet<Truck_Loading_Application.Models.Trip> Trip { get; set; } = default!;
        public DbSet<Truck_Loading_Application.Models.Truck> Truck { get; set; } = default!;
        public DbSet<Truck_Loading_Application.Models.TruckDriver> TruckDriver { get; set; } = default!;
        public DbSet<Truck_Loading_Application.Models.TruckRoute> TruckRoute { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Example: Configure relationship between Trip and Truck
            modelBuilder.Entity<Trip>()
                .HasOne(t => t.Truck)
                .WithMany(t => t.Trips)
                .HasForeignKey(t => t.TruckId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
