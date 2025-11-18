using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebServer.Models;

public partial class BlazorContext : DbContext
{
    public BlazorContext()
    {
    }

    public BlazorContext(DbContextOptions<BlazorContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Entity> Entities { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=Blazor;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Entity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Entity__3214EC07DBA0D96B");

            entity.ToTable("Entity");

            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.Birthday).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
