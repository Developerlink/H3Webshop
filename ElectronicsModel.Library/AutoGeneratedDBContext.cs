using System;
using ElectronicsModel.Library.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ElectronicsModel.Library
{
    public partial class AutoGeneratedDBContext : DbContext
    {
        public AutoGeneratedDBContext()
        {
        }

        public AutoGeneratedDBContext(DbContextOptions<AutoGeneratedDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Delivery> Delivery { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<OrderLine> OrderLine { get; set; }
        public virtual DbSet<OrderStatus> OrderStatus { get; set; }
        public virtual DbSet<PostalCode> PostalCode { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductType> ProductType { get; set; }
        public virtual DbSet<SalesOrder> SalesOrder { get; set; }
        public virtual DbSet<Store> Store { get; set; }
        public virtual DbSet<StoreProduct> StoreProduct { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-AM7NCT3;Initial Catalog=ElectronicsDB;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasIndex(e => e.EmailAddress)
                    .HasName("UQ__Customer__49A147407C0D7695")
                    .IsUnique();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.EmailAddress)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(50);

                //entity.HasOne(d => d.PostalCode)
                //    .WithMany(p => p.Customer)
                //    .HasForeignKey(d => d.PostalCodeId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK__Customer__Addres__2F10007B");
            });

            modelBuilder.Entity<Delivery>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Address).HasMaxLength(100);

                entity.HasOne(d => d.Customer)
                    .WithMany()
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Delivery__Custom__5FB337D6");

                entity.HasOne(d => d.PostalCode)
                    .WithMany()
                    .HasForeignKey(d => d.PostalCodeId)
                    .HasConstraintName("FK__Delivery__Postal__47DBAE45");

                entity.HasOne(d => d.SalesOrder)
                    .WithMany()
                    .HasForeignKey(d => d.SalesOrderId)
                    .HasConstraintName("FK__Delivery__SalesO__46E78A0C");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                //entity.HasOne(d => d.Store)
                    //.WithMany(p => p.Department)
                    //.HasForeignKey(d => d.StoreId)
                    //.OnDelete(DeleteBehavior.ClientSetNull)
                    //.HasConstraintName("FK__Departmen__Store__37A5467C");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasIndex(e => e.EmailAddress)
                    .HasName("UQ__Employee__49A14740351DFA14")
                    .IsUnique();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.EmailAddress)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.WorkEndDate).HasColumnType("datetime");

                entity.Property(e => e.WorkStartDate).HasColumnType("datetime");

                //entity.HasOne(d => d.Department)
                //    .WithMany(p => p.Employee)
                //    .HasForeignKey(d => d.DepartmentId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK__Employee__Depart__60A75C0F");

                //entity.HasOne(d => d.PostalCode)
                //    .WithMany(p => p.Employee)
                //    .HasForeignKey(d => d.PostalCodeId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK__Employee__Postal__3B75D760");
            });

            modelBuilder.Entity<OrderLine>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Product)
                    .WithMany()
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__OrderLine__Produ__44FF419A");

                entity.HasOne(d => d.SalesOrder)
                    .WithMany()
                    .HasForeignKey(d => d.SalesOrderId)
                    .HasConstraintName("FK__OrderLine__Sales__440B1D61");
            });

            modelBuilder.Entity<OrderStatus>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<PostalCode>(entity =>
            {
                entity.Property(e => e.AreaName).HasMaxLength(50);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                //entity.HasOne(d => d.ProductType)
                //    .WithMany(p => p.Product)
                //    .HasForeignKey(d => d.ProductTypeId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK__Product__Product__6EF57B66");
            });

            modelBuilder.Entity<ProductType>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(150);
            });

            modelBuilder.Entity<SalesOrder>(entity =>
            {
                //entity.HasOne(d => d.OrderStatus)
                //    .WithMany(p => p.SalesOrder)
                //    .HasForeignKey(d => d.OrderStatusId)
                //    .HasConstraintName("FK__SalesOrde__Order__4222D4EF");

                //entity.HasOne(d => d.Store)
                //    .WithMany(p => p.SalesOrder)
                //    .HasForeignKey(d => d.StoreId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK__SalesOrde__Store__5EBF139D");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                //entity.HasOne(d => d.PostalCode)
                //    .WithMany(p => p.Store)
                //    .HasForeignKey(d => d.PostalCodeId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK__Store__PostalCod__34C8D9D1");
            });

            modelBuilder.Entity<StoreProduct>(entity =>
            {
                entity.HasNoKey();

                entity.HasOne(d => d.Product)
                    .WithMany()
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__StoreProd__Produ__3E52440B");

                entity.HasOne(d => d.Store)
                    .WithMany()
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__StoreProd__Store__3D5E1FD2");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
