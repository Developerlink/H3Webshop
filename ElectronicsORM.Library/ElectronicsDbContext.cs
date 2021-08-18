using ElectronicsModel.Library.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElectronicsORM.Library
{
    public class ElectronicsDbContext : DbContext
    {
        public ElectronicsDbContext(DbContextOptions<ElectronicsDbContext> options)
            : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Delivery> Delivery { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<OrderLine> OrderLine { get; set; }
        public DbSet<OrderStatus> OrderStatus { get; set; }
        public DbSet<PostalCode> PostalCode { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductType> ProductType { get; set; }
        public DbSet<SalesOrder> SalesOrder { get; set; }
        public DbSet<Store> Store { get; set; }
        public DbSet<StoreProduct> StoreProduct { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderLine>(o =>
            {
                o.HasKey(o => new { o.SalesOrderId, o.ProductId });

                // configures many-to-many relationship
                o.HasOne(o => o.SalesOrder)
                .WithMany(s => s.OrderLines)
                .HasForeignKey(o => o.SalesOrderId);

                o.HasOne(o => o.Product)
                .WithMany(s => s.OrderLines)
                .HasForeignKey(o => o.ProductId);
            });

            modelBuilder.Entity<StoreProduct>(st =>
            {
                st.HasKey(st => new { st.StoreId, st.ProductId });

                // configures many-to-many relationship
                st.HasOne(st => st.Store)
                .WithMany(store => store.StoreProducts)
                .HasForeignKey(st => st.StoreId);

                st.HasOne(st => st.Product)
                .WithMany(product => product.StoreProducts)
                .HasForeignKey(st => st.ProductId);
            });

            modelBuilder.Entity<Delivery>(d =>
            {
                d.HasKey(d => new { d.SalesOrderId, d.CustomerId, d.PostalCodeId });

                // configures one-to-many relationship
                d.HasOne(d => d.Customer)
                .WithMany(c => c.Deliveries)
                .HasForeignKey(d => d.CustomerId);

                d.HasOne(d => d.PostalCode)
                .WithMany(p => p.Deliveries)
                .HasForeignKey(d => d.PostalCodeId);
            });

            modelBuilder.Entity<PostalCode>().HasKey(p => p.PostalCodeId);
        }
    }
}
