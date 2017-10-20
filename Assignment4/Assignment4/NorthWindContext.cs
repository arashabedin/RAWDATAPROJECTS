using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using DataServiceProject.Models;

namespace DataServiceProject
{
    public class NorthwindContext : DbContext
    {

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseMySql(
                  "server=localhost;database=north;uid=root;");
            //  "server=localhost;database=paractics;uid=root;pwd=root");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Categories

            modelBuilder.Entity<Category>().ToTable("categories");
            modelBuilder.Entity<Category>()
            .Property(x => x.Id).HasColumnName("CategoryId");

            modelBuilder.Entity<Category>()
                .Property(x => x.Name).HasColumnName("CategoryName");

            modelBuilder.Entity<Category>()
            .Property(x => x.Description).HasColumnName("Description");

            /*
            modelBuilder.Entity<Category>()
           .HasMany(s => s.Product)
           .WithOne(g => g.Category)
           .HasPrincipalKey(p => p.Id)
           .HasForeignKey(f => f.CategoryId);

    */

            //Products

            modelBuilder.Entity<Product>().ToTable("products");
            modelBuilder.Entity<Product>()
            .Property(x => x.Id).HasColumnName("ProductId");
            modelBuilder.Entity<Product>()
           .Property(x => x.Name).HasColumnName("ProductName");
            modelBuilder.Entity<Product>()
           .Property(x => x.SupplierId).HasColumnName("SupplierId");
            modelBuilder.Entity<Product>()
           .Property(x => x.CategoryId).HasColumnName("CategoryId");


            modelBuilder.Entity<Product>()
         .Property(x => x.QuantityPerUnit).HasColumnName("QuantityUnit");

            modelBuilder.Entity<Product>()
           .Property(x => x.UnitPrice).HasColumnName("UnitPrice");

            modelBuilder.Entity<Product>()
        .Property(x => x.UnitsInStock).HasColumnName("UnitsInStock");



            // configures one-to-many relationship

            modelBuilder.Entity<Product>()
           .HasOne(s => s.Category)
           .WithMany(p => p.Product);


            //Order


            modelBuilder.Entity<Order>().ToTable("orders");
            modelBuilder.Entity<Order>()
            .Property(x => x.Id).HasColumnName("OrderId");
            modelBuilder.Entity<Order>()
           .Property(x => x.Date).HasColumnName("OrderDate");
            modelBuilder.Entity<Order>()
           .Property(x => x.Required).HasColumnName("RequiredDate");
            modelBuilder.Entity<Order>()
           .Property(x => x.Shipped).HasColumnName("ShippedDate");


            modelBuilder.Entity<Order>()
         .Property(x => x.Frieght).HasColumnName("Freight");

            modelBuilder.Entity<Order>()
           .Property(x => x.ShipName).HasColumnName("ShipName");

            modelBuilder.Entity<Order>()
        .Property(x => x.ShipCity).HasColumnName("ShipCity");

            //OrderDetails


            modelBuilder.Entity<OrderDetails>().ToTable("orderdetails");
            modelBuilder.Entity<OrderDetails>()
        .HasKey(op => new { op.OrderId, op.ProductId });

            modelBuilder.Entity<OrderDetails>()
               .Property(x => x.OrderId).HasColumnName("OrderId");
            modelBuilder.Entity<OrderDetails>()
           .Property(x => x.ProductId).HasColumnName("ProductId");

            modelBuilder.Entity<OrderDetails>()
            .Property(x => x.UnitPrice).HasColumnName("UnitPrice");

            modelBuilder.Entity<OrderDetails>()
             .Property(x => x.Quantity).HasColumnName("Quantity");

            modelBuilder.Entity<OrderDetails>()
              .Property(x => x.Discount).HasColumnName("Discount");









        }




    }
}
