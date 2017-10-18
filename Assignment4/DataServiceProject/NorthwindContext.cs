using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace DataServiceProject
{
    class NorthwindContex : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseMySql(
                "server=localhost;database=north;uid=root;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Categories
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().ToTable("categories");
            modelBuilder.Entity<Category>()
            .Property(x => x.Id).HasColumnName("CategoryId");

            modelBuilder.Entity<Category>()
                .Property(x => x.Name).HasColumnName("CategoryName");

            modelBuilder.Entity<Category>()
            .Property(x => x.Description).HasColumnName("Description");



            //Products
            modelBuilder.Entity<Product>().ToTable("products");
            modelBuilder.Entity<Product>()
            .Property(x => x.Id).HasColumnName("ProductId");
            modelBuilder.Entity<Product>()
           .Property(x => x.Name).HasColumnName("ProductName");
            modelBuilder.Entity<Product>()
                .Property(x => x.UnitPrice).HasColumnName("ProductUnitPrice");
            modelBuilder.Entity<Product>()
                .Property(x => x.QuantityPerUnit).HasColumnName("ProductQuantityPerUnit");
            modelBuilder.Entity<Product>()
                .Property(x => x.UnitsInStock).HasColumnName("ProductUnitsInStock");



        }




    }
}
