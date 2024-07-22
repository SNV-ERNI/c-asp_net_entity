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
        public DbSet<TransactionHistoryEntity> TransactionHistoryEntities { get; set; }

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

            // Configure TransactionHistoryEntity
            modelBuilder.Entity<TransactionHistoryEntity>()
                .HasKey(th => th.TransID);

            modelBuilder.Entity<TransactionHistoryEntity>()
                .HasOne(th => th.PurchaseOrder)
                .WithMany()
                .HasForeignKey(th => th.OrderID);
        }
    }
}