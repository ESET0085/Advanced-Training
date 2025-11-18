using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Online_Product_Inventory_Management_System.Models;

namespace Online_Product_Inventory_Management_System.Data;

public partial class ProductInventoryContext : DbContext
{
    public ProductInventoryContext()
    {
    }

    public ProductInventoryContext(DbContextOptions<ProductInventoryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
     => optionsBuilder.UseSqlServer("Data Source=LAPTOP-FPM8VUF2\\SQLEXPRESS;Initial Catalog=ProductInventory;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Categori__19093A0B3B8C5275");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Products__B40CC6CDD43EBE04");

            entity.HasOne(d => d.Category).WithMany(p => p.Products).HasConstraintName("FK_Products_Categories");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
