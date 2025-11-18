using AMI_Project.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace AMI_Project.Data
{
    public  class AMIDbContext : DbContext
    {
        public AMIDbContext() { }

        public AMIDbContext(DbContextOptions<AMIDbContext> options)
            : base(options) { }

        public virtual DbSet<Billing> Billings { get; set; }
        public virtual DbSet<Consumer> Consumers { get; set; }
        public virtual DbSet<Meter> Meters { get; set; }
        public virtual DbSet<OrgUnit> OrgUnits { get; set; }
        public virtual DbSet<Tariff> Tariffs { get; set; }
        public virtual DbSet<TariffSlab> TariffSlabs { get; set; }
        public virtual DbSet<User> Users { get; set; }

        // Leave empty if DbContext is configured in Program.cs
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Billing>(entity =>
            {
                entity.HasKey(e => e.BillId);
                entity.Property(e => e.GeneratedAt).HasDefaultValueSql("sysutcdatetime()");
                entity.Property(e => e.Status).HasDefaultValue("Pending");

                entity.HasOne(d => d.Consumer)
                      .WithMany(p => p.Billings)
                      .HasForeignKey(d => d.ConsumerId)
                      .OnDelete(DeleteBehavior.ClientSetNull)
                      .HasConstraintName("FK__Billing__Consumer");
            });

            modelBuilder.Entity<Consumer>(entity =>
            {
                entity.HasKey(e => e.ConsumerId);
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("sysutcdatetime()");
                entity.Property(e => e.CreatedBy).HasDefaultValue("system");
                entity.Property(e => e.Status).HasDefaultValue("Active");

                entity.HasOne(d => d.OrgUnit)
                      .WithMany(p => p.Consumers)
                      .HasForeignKey(d => d.OrgUnitId)
                      .OnDelete(DeleteBehavior.ClientSetNull)
                      .HasConstraintName("FK__Consumer__OrgUnit");

                entity.HasOne(d => d.Tariff)
                      .WithMany(p => p.Consumers)
                      .HasForeignKey(d => d.TariffId)
                      .OnDelete(DeleteBehavior.ClientSetNull)
                      .HasConstraintName("FK__Consumer__Tariff");
            });

            modelBuilder.Entity<Meter>(entity =>
            {
                entity.HasKey(e => e.MeterSerialNo);
                entity.Property(e => e.Status).HasDefaultValue("Active");

                entity.HasOne(d => d.Consumer)
                      .WithMany(p => p.Meters)
                      .HasForeignKey(d => d.ConsumerId)
                      .OnDelete(DeleteBehavior.ClientSetNull)
                      .HasConstraintName("FK__Meter__Consumer");
            });

            modelBuilder.Entity<OrgUnit>(entity =>
            {
                entity.HasKey(e => e.OrgUnitId);

                entity.HasOne(d => d.Parent)
                      .WithMany(p => p.InverseParent)
                      .HasForeignKey(d => d.ParentId)
                      .OnDelete(DeleteBehavior.ClientSetNull)
                      .HasConstraintName("FK__OrgUnit__Parent");
            });

            modelBuilder.Entity<Tariff>(entity =>
            {
                entity.HasKey(e => e.TariffId);
            });

            modelBuilder.Entity<TariffSlab>(entity =>
            {
                entity.HasKey(e => e.TariffSlabId);

                entity.HasOne(d => d.Tariff)
                      .WithMany(p => p.TariffSlabs)
                      .HasForeignKey(d => d.TariffId)
                      .OnDelete(DeleteBehavior.ClientSetNull)
                      .HasConstraintName("FK__TariffSlab__Tariff");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId);
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("sysutcdatetime()");
                entity.Property(e => e.Status).HasDefaultValue("Active");
            });

            //OnModelCreatingPartial(modelBuilder);
        }


        //public void OnModelCreatingPartial(ModelBuilder modelBuilder);
        

        
    }
}