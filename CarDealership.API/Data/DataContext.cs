using CarDealership.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarDealership.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<CarsEntity> CarsEntities { get; set; }
        public DbSet<CustomersEntity> CustomerEntities { get; set; }
        public DbSet<PurchaseOrderEntity> PurchaseOrderEntities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure CarEntity
            modelBuilder.Entity<CarsEntity>()
                .HasKey(c => c.VIN);

            // Configure CustomerEntity
            modelBuilder.Entity<CustomersEntity>()
                .HasKey(c => c.CustomerID);

            // Configure PurchaseOrderEntity
            modelBuilder.Entity<PurchaseOrderEntity>()
                .HasKey(po => po.OrderID);

            modelBuilder.Entity<PurchaseOrderEntity>()
                .HasOne(po => po.Car)
                .WithMany()
                .HasForeignKey(po => po.VIN);

            modelBuilder.Entity<PurchaseOrderEntity>()
                .HasOne(po => po.Customer)
                .WithMany()
                .HasForeignKey(po => po.CustomerID);
        }
    }
}